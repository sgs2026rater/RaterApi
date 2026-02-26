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
    private readonly IMagicPolicyRepository _magicPolicyRepository;
    private readonly IGeographicModRepository _geographicModRepository;
    
    private readonly IIndustrySectorRepository _industrySectorRepository;
    private readonly IIndustrySubSectorRepository _industrySubSectorRepository;
    private readonly IIndustrySpecialtyRepository _industrySpecialtyRepository;

    private readonly RaterDetails _raterDetails = new();
    private readonly ILogger _logger;
    private List<IndustrySector>? _industrySectors;
    private List<IndustrySubSector>? _industrySubSectors;
    private List<IndustrySpecialty>? _industrySpecialties;
    private readonly RaterOptions _raterOptions;


    public RaterService(
        IMemoryCache memoryCache,
        ILogger<RaterService> logger,
        IMagicPolicyRepository magicPolicyRepository,
        IGeographicModRepository geographicModRepository,
        IIndustrySectorRepository industrySectorRepository,
        IIndustrySubSectorRepository industrySubSectorRepository,
        IIndustrySpecialtyRepository industrySpecialtyRepository,
        IOptionsMonitor<RaterOptions> raterOptions)
    {
        _logger = logger;
        _magicPolicyRepository = magicPolicyRepository;
        _geographicModRepository= geographicModRepository;
        _industrySectorRepository = industrySectorRepository;
        _industrySubSectorRepository = industrySubSectorRepository;
        _industrySpecialtyRepository = industrySpecialtyRepository;
        _raterOptions = raterOptions.CurrentValue;
    }


    public async Task<Result<RaterResult, RaterFailureDetails>> GetRateInformation(RaterInputs raterInputs)
    {
        _logger.LogInformation("Validate if Policy number is provided and does exist.");
        if (!await ValidatePolicyNumberAndLoad(raterInputs))
        {
            return new RaterFailureDetails("InvalidPolicyNumber", "Policy Number is invalid.");
        }

        _logger.LogInformation("Validate if Zip Code is provided and does exist.");
        if (!await ValidateZipCode(_raterDetails.Profile!.Zip))
        {
            return new RaterFailureDetails("InvalidZipCode", "Zip Code is invalid.");
        }

        _logger.LogInformation("Loading data.");
        await LoadData();

        _logger.LogInformation("Validate industry classifications.");
        if (!ValidateIndustryClassifications(raterInputs.IndustryClassifications!, _raterDetails))
        {
            return new RaterFailureDetails("InvalidIndustryClassification", "One or more industry classifications are invalid.");
        }

        //Validate sum of exposure percentages
        if (!ValidateTotalExposure(_raterDetails))
        {
            return new RaterFailureDetails("InvalidExposurePercentages", "Exposures must sum to 100%.");
        }

        var coverage = GetPrimaryCoverage(raterInputs.Coverages!);

        if ((coverage?.OccuranceLimit ?? 0m) != (_raterDetails?.Profile.EO_OccLimit ?? 0m))
        {
            _logger.LogWarning("OccuranceLimit ({0}) of Coverages in the request does not match with the Magic database ({1}).",
                                            coverage?.OccuranceLimit ?? 0m, decimal.Truncate(_raterDetails?.Profile.EO_OccLimit ?? 0m));
        }
        if ((coverage?.AggregateLimit ?? 0m) != (_raterDetails?.Profile.EO_AggLimit ?? 0m))
        {
            _logger.LogWarning("AggregateLimit ({0}) of Coverages in the request does not match with the Magic database ({1}).",
                                            coverage?.AggregateLimit ?? 0m, decimal.Truncate(_raterDetails?.Profile.EO_AggLimit ?? 0m));
        }
        if ((coverage?.Retention ?? 0m) != (_raterDetails?.Profile.EO_Retention ?? 0m))
        {
            _logger.LogWarning("Retention ({0}) of Coverages in the request does not match with the Magic database ({1}).",
                                            coverage?.Retention ?? 0m, decimal.Truncate(_raterDetails?.Profile.EO_Retention ?? 0m));
        }

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
    /// Validates Policy Number provided in the rating inputs for availability and also against the available magic policy data loaded from the repositories. 
    /// If Policy Number is invalid, it returns false. If it is valid, it populates field and returns true.
    /// </summary>
    /// <param name="policyNumber"></param>
    /// <returns>A flag indicating whether Policy Number is provided and exists.</returns>
    private async Task<bool> ValidatePolicyNumberAndLoad(RaterInputs raterInputs)
    {
        if (string.IsNullOrEmpty(raterInputs.PolicyNumber)) return false;

        _raterDetails.Profile = await _magicPolicyRepository.GetByPolicyNumber(_raterOptions.Version, raterInputs.PolicyNumber);

        if (_raterDetails.Profile == null) return false;

        _raterDetails.Profile!.Revenue = raterInputs.Revenue;
        _raterDetails.Profile.EO = true;

        return true;
    }

    /// <summary>
    /// Validates Zip Code provided in the rating inputs for availability and also against the available Zip Code data loaded from the repositories. 
    /// If Zip Code is invalid, it returns false. If it is valid, it populates field and returns true.
    /// </summary>
    /// <param name="zipCode"></param>
    /// <returns>A flag indicating whether Zip Code is provided and exists.</returns>
    private async Task<bool> ValidateZipCode(string? zipCode)
    {
        if (string.IsNullOrEmpty(zipCode)) return false;

        _raterDetails.Profile?.MetroArea = await _geographicModRepository.GetMetroArea(_raterOptions.Version, zipCode);

        if (_raterDetails.Profile?.MetroArea == null) return false;

        return true;
    }

    /// <summary>
    /// Validates the industry classifications provided in the rating inputs against the reference data loaded from the repositories. 
    /// If any classification is invalid, it returns false. If all classifications are valid, it populates the corresponding IDs in the industry classifications and returns true.
    /// </summary>
    /// <param name="industryClassifications"></param>
    /// <param name="worksheet"></param>
    /// <returns>A flag indicating whether the industry classifications are valid.</returns>
    private bool ValidateIndustryClassifications(IEnumerable<IndustryClassification> industryClassifications, RaterDetails worksheet)
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

            if (matchingIndustrySubSector.IndustrySectorId != matchingIndustrySector.Id)
                return false;
            if (matchingIndustrySpecialty.IndustrySubSectorId != matchingIndustrySubSector.Id)
                return false;

            industryClassification.SectorId = matchingIndustrySector.Id;
            industryClassification.SubSectorId = matchingIndustrySubSector.Id;
            industryClassification.SpecialtyId = matchingIndustrySpecialty.Id;
        }

        worksheet.IndustryClassifications = industryClassifications.ToList();
        return true;
    }

    private static bool ValidateTotalExposure(RaterDetails worksheet)
    {
        return worksheet.IndustryClassifications!.Sum(_ => _.PercentageExposure) == 1m;
    }

    private static Coverage? GetPrimaryCoverage(List<Coverage> coverages)
    {
        return coverages.FirstOrDefault(c => c.CoverageType == CoverageType.EAndOPrimary);
    }

}
