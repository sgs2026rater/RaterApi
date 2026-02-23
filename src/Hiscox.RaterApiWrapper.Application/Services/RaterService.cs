// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApiWrapper.Application.Abstractions;
using Hiscox.RaterApiWrapper.Domain.Abstractions;
using Hiscox.RaterApiWrapper.Domain.Configuration;
using Hiscox.RaterApiWrapper.Domain.Entities;
using Hiscox.RaterApiWrapper.Domain.Enums;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Hiscox.RaterApiWrapper.Application.Services;

public class RaterService : IRaterService
{
    private readonly IIndustrySectorRepository _industrySectorRepository;
    private readonly IIndustrySubSectorRepository _industrySubSectorRepository;
    private readonly IIndustrySpecialtyRepository _industrySpecialtyRepository;

    private readonly RaterWorksheet _raterWorksheet = new();
    private readonly ILogger _logger;
    private List<IndustrySector>? _industrySectors;
    private List<IndustrySubSector>? _industrySubSectors;
    private List<IndustrySpecialty>? _industrySpecialties;
    private readonly RaterOptions _raterOptions;


    public RaterService(
        IMemoryCache memoryCache,
        ILogger<RaterService> logger,
        IIndustrySectorRepository industrySectorRepository,
        IIndustrySubSectorRepository industrySubSectorRepository,
        IIndustrySpecialtyRepository industrySpecialtyRepository,
        IOptionsMonitor<RaterOptions> raterOptions)
    {
        _logger = logger;
        _industrySectorRepository = industrySectorRepository;
        _industrySubSectorRepository = industrySubSectorRepository;
        _industrySpecialtyRepository = industrySpecialtyRepository;
        _raterOptions = raterOptions.CurrentValue;
    }


    public async Task<Result<RaterResult, RaterFailureDetails>> GetRateInformation(RaterInputs raterInputs)
    {
        _logger.LogInformation("Loading data.");
        await LoadData();

        _logger.LogInformation("Validate industry classifications.");
        if (!ValidateIndustryClassifications(raterInputs.IndustryClassifications!, _raterWorksheet))
        {
            return new RaterFailureDetails("InvalidIndustryClassification", "One or more industry classifications are invalid.");
        }

        //Validate sum of exposure percentages
        if (!ValidateTotalExposure(_raterWorksheet))
        {
            return new RaterFailureDetails("InvalidExposurePercentages", "Exposures must sum to 100%.");
        }

        var coverage = GetPrimaryCoverage(raterInputs.Coverages!);

        //Entering mock values for now

        return new RaterResult()
        {
            RaterVersion = _raterOptions.Version,
            RaterVersionDate = _raterOptions.VersionDate,
            OccuranceLimit = coverage?.OccuranceLimit ?? 0m,
            AggregateLimit = coverage?.AggregateLimit ?? 0m,
            Retention = coverage?.Retention ?? 0m,
            ExpiringPremium = 2046m,
            RenewalPremium = 1963m,
            RevenueChange = 0.5m,
            PremiumChange = -0.04m,
            RateChange =  -0.21m
        };
    }

    /// <summary>
    /// Loads the industry sectors, sub-sectors, and specialties from their respective repositories based on the version specified in the rating worksheet configuration.
    /// </summary>
    /// <returns>A Task object</returns>
    private async Task LoadData()
    {
        _industrySectors = (await _industrySectorRepository.GetAll(_raterOptions.Version)).ToList();
        _industrySubSectors = (await _industrySubSectorRepository.GetAll(_raterOptions.Version)).ToList();
        _industrySpecialties = (await _industrySpecialtyRepository.GetAll(_raterOptions.Version)).ToList();
    }


    /// <summary>
    /// Validates the industry classifications provided in the rating inputs against the reference data loaded from the repositories. 
    /// If any classification is invalid, it returns false. If all classifications are valid, it populates the corresponding IDs in the industry classifications and returns true.
    /// </summary>
    /// <param name="industryClassifications"></param>
    /// <param name="worksheet"></param>
    /// <returns>A flag indicating whether the industry classifications are valid.</returns>
    private bool ValidateIndustryClassifications(IEnumerable<IndustryClassification> industryClassifications, RaterWorksheet worksheet)
    {
        foreach (var industryClassification in industryClassifications)
        {
            var matchingIndustrySector = _industrySectors!.FirstOrDefault(_ => _.Name == industryClassification.SectorName);
            if (matchingIndustrySector is null)
            {
                return false;
            }

            var matchingIndustrySubSector = _industrySubSectors!.FirstOrDefault(_ => _.Name == industryClassification.SubSectorName);
            if (matchingIndustrySubSector is null)
            {
                return false;
            }

            var matchingIndustrySpecialty = _industrySpecialties!.FirstOrDefault(_ => _.Name == industryClassification.SpecialtyName);
            if (matchingIndustrySpecialty is null)
            {
                return false;
            }

            industryClassification.SectorId = matchingIndustrySector.Id;
            industryClassification.SubSectorId = matchingIndustrySubSector.Id;
            industryClassification.SpecialtyId = matchingIndustrySpecialty.Id;
        }

        worksheet.IndustryClassifications = industryClassifications.ToList();
        return true;
    }

    private static bool ValidateTotalExposure(RaterWorksheet worksheet)
    {
        return worksheet.IndustryClassifications!.Sum(_ => _.PercentageExposure) == 1m;
    }

    private static Coverage? GetPrimaryCoverage(List<Coverage> coverages)
    {
        return coverages.FirstOrDefault(c => c.CoverageType == CoverageType.EAndOPrimary);
    }

}
