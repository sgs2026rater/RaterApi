// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApiWrapper.Application.Abstractions;
using Hiscox.RaterApiWrapper.Domain.Abstractions;
using Hiscox.RaterApiWrapper.Domain.Configuration;
using Hiscox.RaterApiWrapper.Domain.Entities;
using Hiscox.RaterApiWrapper.Domain.Enums;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Runtime.CompilerServices;

namespace Hiscox.RaterApiWrapper.Application.Services;

public class RaterService : IRaterService
{
    private readonly IMagicPolicyRepository _magicPolicyRepository;
    private readonly IGeographicModRepository _geographicModRepository;

    private readonly IIndustrySectorRepository _industrySectorRepository;
    private readonly IIndustrySubSectorRepository _industrySubSectorRepository;
    private readonly IIndustrySpecialtyRepository _industrySpecialtyRepository;

    private readonly IFormRepository _formRepository;
    private readonly IFormEligibilityRepository _formEligibilityRepository;

    private readonly RaterDetails _raterDetails = new();
    private readonly ILogger _logger;
    private List<IndustrySector>? _industrySectors;
    private List<IndustrySubSector>? _industrySubSectors;
    private List<IndustrySpecialty>? _industrySpecialties;
    private List<Form>? _forms;
    private readonly RaterOptions _raterOptions;


    public RaterService(
        IMemoryCache memoryCache,
        ILogger<RaterService> logger,
        IMagicPolicyRepository magicPolicyRepository,
        IGeographicModRepository geographicModRepository,
        IIndustrySectorRepository industrySectorRepository,
        IIndustrySubSectorRepository industrySubSectorRepository,
        IIndustrySpecialtyRepository industrySpecialtyRepository,
        IOptionsMonitor<RaterOptions> raterOptions,
        IFormRepository formRepository,
        IFormEligibilityRepository formEligibilityRepository)
    {
        _logger = logger;
        _magicPolicyRepository = magicPolicyRepository;
        _geographicModRepository = geographicModRepository;
        _industrySectorRepository = industrySectorRepository;
        _industrySubSectorRepository = industrySubSectorRepository;
        _industrySpecialtyRepository = industrySpecialtyRepository;
        _raterOptions = raterOptions.CurrentValue;
        _formRepository = formRepository;
        _formEligibilityRepository = formEligibilityRepository;
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

        //var eligibleForms = await GetEligibileForms(_raterDetails.PrimaryIndustryClassification!.SpecialtyId!.Value);

        //Validate sum of exposure percentages
        if (!ValidateTotalExposure(_raterDetails))
        {
            return new RaterFailureDetails("InvalidExposurePercentages", "Exposures must sum to 100%.");
        }

        _raterDetails.Revenue = raterInputs.Revenue;
        AdditionalUWCalculation(raterInputs.AdditionalRiskProfile);

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
            RateChange = -0.21m
        };
    }

    private void AdditionalUWCalculation(AdditionalRiskProfile? additionalRiskProfile)
    {
        //To calculate UITrigAnEFlag
        _raterDetails.UITrigAnEFlag = (_raterDetails.PrimaryIndustryClassification?.SectorName == "Design Professionals") ||
            (_raterDetails.PrimaryIndustryClassification?.SectorName == "Contractors") ||
            (_raterDetails.PrimaryIndustryClassification?.SectorName == "A&E Technical Consulting");
        //To Calculate RevenueAdjusted
        if (_raterDetails.PrimaryIndustryClassification?.SectorName == "Contractors")
        {
            //TODO:There is a formula to calculate this.It is not part of Design Professional workflow.
        }
        else
        {
            if (_raterDetails.PrimaryIndustryClassification?.SectorName == "Property Management - Standalone")
            {
                //TODO: There is a formula to calculate this.It is not part of Design Professional workflow.
            }
            else
            {
                if (_raterDetails.PrimaryIndustryClassification?.SubSectorName == "Real Estate Developers")
                {
                    //TODO: There is a formula to calculate this.It is not part of Design Professional workflow.
                }
                else
                {
                    if (false)// bed_and_revenue - = AND(D645 > 0, D646 > 0).TODO: There is a formula to calculate this.It is not part of Design Professional workflow.
                    {
                        //TODO: There is a formula to calculate this.It is not part of Design Professional workflow.
                    }
                    else
                    {
                        _raterDetails.RevenueAdjusted = _raterDetails.Revenue;
                    }

                }
            }
        }

        //TODO: Comments to be removed after implementation of below logic.
        //=IF(industry_sector="Contractors",AND(cv_total<>0,cv_total<=3000000,ui_trig_ane_flag=TRUE),
        //OR(AND(revenue<>0,revenue<=3000000,ui_trig_ane_flag=TRUE),
        //AND(revenue_adjusted<>0,revenue_adjusted<=3000000,ui_trig_ane_flag=TRUE)))
        /* industry_sector - Sector selected in Industry sheet.
 cv_total - This is the sum of values we enter in Risk Profile Sheet for Contractors sector.
 ui_trig_ane_flag - = OR(industry_sector = "Design Professionals", industry_sector = "Contractors", industry_sub_sector = "A&E Technical Consulting")
 revenue - Revenue entered in Profile tab
 revenue_adjusted - Present in Calculations sheet.

                     = IF(industry_sector = "Contractors",
                         adjusted_fees,
                         IF(industry = "Property Management - Standalone",
                             $F$77,
                             IF(F88,
                                 F89,
                                     IF(bed_and_revenue,
                                         D666,
                                         revenue))))
 adjusted_fees - Sum of products of Constuction Value and Rate.Calculations!H74
 industy - = Industry_lookup!S62.This comes from industry tab and depends on all three values selected.
 $F$77 - = 0.1 * alternative_exposure_value.alternative_exposure_value comes from Risk Profile tab on enabling Alternative exposure in Profile tab.
 F88 - = industry_sub_sector = "Real Estate Developers"
 F89 - = red_exposure.red_exposure is CK71 in Risk Profile tab.It is hidden for Design Professionals.
 bed_and_revenue - = AND(D645 > 0, D646 > 0).
 D645 - Atleast one bed specialty ? - = COUNTIFS($Q$34:$Q$42, "Number of beds").Each of Q34 to Q42 have other formulas.TODO:.
 D646 - Atleast one revenue rated specialty ? - = COUNTIFS($Q$34:$Q$42, "Revenue").Each of Q34 to Q42 have other formulas.TODO:.
 D666 - = MAX(revenue - D664, 0) TODO: 
 D664 - Total Bed cost post geo mod. = D660 * D662.Where D660 is Total Bed cost and D662 is geo modifier. Total Bed Cost has its own formula and Geo mod is a vlookup.@TODO:*/

        //To Calculate UITrigDesignprof3MRevFlag
        //Assumption is the first value is the Primary Industry Name. In case if its not, implement the logic for Primary Industry Info.
        if (_raterDetails.PrimaryIndustryClassification?.SectorName == "Contractors")
        {
            //TODO:  Calculate _raterDetails.UITrigDesignprof3MRevFlag here.The above Formula

        }
        else
        {
            _raterDetails.UITrigDesignprof3MRevFlag = (_raterDetails.Revenue != 0 && _raterDetails.Revenue <= 3000000 && _raterDetails.UITrigAnEFlag) ||
            (_raterDetails.RevenueAdjusted != 0 && _raterDetails.RevenueAdjusted <= 3000000 && _raterDetails.UITrigAnEFlag);
        }

        if (additionalRiskProfile?.TangibleGoodsOrProduct == true)
        {
            _raterDetails.TangibleGoodsOrProductOwnerFlag = true;
        }
        if (additionalRiskProfile?.ProjectTypes?.Count == 0)
        {
            //foreach(ProjectType projectType in additionalRiskProfile.ProjectTypes)
            foreach (string projectType in additionalRiskProfile.ProjectTypes)
            {
                //=IFERROR(IF(NOT(ui_trig_designprof_3MRev_Flag),project_tier4_listing_above5M,
                //LEFT(project_tier_4_list,LEN(project_tier_4_list)-2)),"")
                if (_raterDetails.UITrigDesignprof3MRevFlag)
                {
                    //if(projectType == ProjectType.CivilOrInfrastructure)
                    //{ }
                    //if(projectType == ProjectType.Commercial)
                    if (projectType == "Commercial")
                    {
                        _raterDetails.ProjectTier4Ans = _raterDetails.ProjectTier4Ans || additionalRiskProfile.DataCenters ||
                                additionalRiskProfile.MajorStadiumArena || additionalRiskProfile.StandAlongParking;
                        _raterDetails.ProjectTier5Ans = _raterDetails.ProjectTier5Ans || additionalRiskProfile.OfficeHighRiseSkyscrapers;
                    }
                    //if (projectType == ProjectType.Industrial)
                    //{}
                    //if (projectType == ProjectType.Institutional)
                    //{ }
                    //if (projectType == ProjectType.PowerAndUtilities)
                    //{}
                    //if (projectType == ProjectType.MultiUnitResidentialCommunities)
                    //{ }
                    //if (projectType == ProjectType.ResidentialAndApartments)
                    if (projectType == "ResidentialAndApartments")
                    {
                        _raterDetails.ProjectTier4Ans = _raterDetails.ProjectTier4Ans || additionalRiskProfile.HighValueHomes
                           || additionalRiskProfile.SeniorHousingAssistedLiving || additionalRiskProfile.LowIncomeHousing;
                        _raterDetails.ProjectTier5Ans = _raterDetails.ProjectTier5Ans || additionalRiskProfile.TractHomes;
                    }
                }
                else
                {
                    //Similar logic as the If block except the properties it considers are filtered for Revenue>5M.(Not Applicable for Design Professional Workflow)
                    //TODO:
                }

            }

        }
        //=NOT(OR(AND(ui_control!$B$195,$DN$269="Most of the time (>=75% but <95%)"),$DN$269="Always (>=95%)"))
        if (!(_raterDetails.UITrigDesignprof3MRevFlag && (int?)(additionalRiskProfile?.WorkUndertakenFrequencyQuestion) >= 3))
        {
            _raterDetails.LimitationOfLiabilityQuestionFlag = true;
        }
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
        _forms = (await _formRepository.GetAll(_raterOptions.Version)).ToList();
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
        if (!industryClassifications.Any())
        {
            return false;
        }
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
        worksheet.PrimaryIndustryClassification = worksheet.IndustryClassifications[0];//Assuming the first value as Primary Industry info
        return true;
    }

    private async Task<IEnumerable<Form>?> GetEligibileForms(int industrySpecialtyId)
    {
        var eligibileFormIds = (await _formEligibilityRepository.GetForIndustrySpeciality(_raterOptions.Version, industrySpecialtyId))
            .Select(_ => _.FormId);
        if (eligibileFormIds.Any())
        {
            return _forms!.Where(_ => eligibileFormIds.Contains(_.Id));
        }

        return null;
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
