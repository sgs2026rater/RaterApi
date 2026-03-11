// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApiWrapper.Application.Abstractions;
using Hiscox.RaterApiWrapper.Domain.Abstractions;
using Hiscox.RaterApiWrapper.Domain.Configuration;
using Hiscox.RaterApiWrapper.Domain.Entities;
using Hiscox.RaterApiWrapper.Domain.Enums;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Data;

namespace Hiscox.RaterApiWrapper.Application.Services;

public class RaterService : IRaterService
{
    private readonly IMagicPolicyRepository _magicPolicyRepository;
    private readonly IGeographicModRepository _geographicModRepository;

    private readonly IIndustrySectorRepository _industrySectorRepository;
    private readonly IIndustrySubSectorRepository _industrySubSectorRepository;
    private readonly IIndustrySpecialtyRepository _industrySpecialtyRepository;
    private readonly IRatingFactorsRepository _iRatingFactorsRepository;

    private readonly IFormRepository _formRepository;
    private readonly IFormEligibilityRepository _formEligibilityRepository;
    private readonly ILookupRepository _lookupRepository;
    private readonly ILimitRetentionFactorRepository _limitRetentionFactorRepository;
    private readonly IOccLimitFactorRepository _occLimitFactorRepository;
    private readonly IProjectTypeFactorRepository _projectTypeFactorRepository;
    private readonly IRetainedValueFactorRepository _retainedValueFactorRepository;
    private readonly IRetainedValueFactorMatrixRepository _retainedValueFactorMatrixRepository;
    private readonly IRevenueBaseRateRepository _revenueBaseRateRepository;
    

    private readonly IIncludedCoverageEnhancementsRepository _includedCoverageEnhancementsRepository;
    private readonly IOptCovTable1Repository _optCovTable1Repository;
    private readonly IOptionalCoverageTable1Repository _optionalCoverageTable1Repository;

    private readonly RaterDetails _raterDetails = new();
    private readonly ILogger _logger;
    private List<IndustrySector>? _industrySectors;
    private List<IndustrySubSector>? _industrySubSectors;
    private List<IndustrySpecialty>? _industrySpecialties;
    private List<Form>? _forms;
    private readonly RaterOptions _raterOptions;
    private readonly decimal _defaultRatingFactor = 1;


    public RaterService(
        IMemoryCache memoryCache,
        ILogger<RaterService> logger,
        IMagicPolicyRepository magicPolicyRepository,
        IGeographicModRepository geographicModRepository,
        IIndustrySectorRepository industrySectorRepository,
        IIndustrySubSectorRepository industrySubSectorRepository,
        IIndustrySpecialtyRepository industrySpecialtyRepository,
        IOptionsMonitor<RaterOptions> raterOptions,
        IRatingFactorsRepository iRatingFactorsRepository,
        IFormRepository formRepository,
        IFormEligibilityRepository formEligibilityRepository,
        ILookupRepository lookupRepository,
        ILimitRetentionFactorRepository limitRetentionFactorRepository,
        IOccLimitFactorRepository occLimitFactorRepository,
        IProjectTypeFactorRepository projectTypeFactorRepository,
        IRetainedValueFactorRepository retainedValueFactorRepository,
        IRetainedValueFactorMatrixRepository retainedValueFactorMatrixRepository,
        IRevenueBaseRateRepository revenueBaseRateRepository)
        ILookupRepository lookupRepository, IIncludedCoverageEnhancementsRepository includedCoverageEnhancementsRepository,
        IOptCovTable1Repository optCovTable1Repository,
        IOptionalCoverageTable1Repository optionalCoverageTable1Repository)
    {
        _logger = logger;
        _magicPolicyRepository = magicPolicyRepository;
        _geographicModRepository = geographicModRepository;
        _industrySectorRepository = industrySectorRepository;
        _industrySubSectorRepository = industrySubSectorRepository;
        _industrySpecialtyRepository = industrySpecialtyRepository;
        _raterOptions = raterOptions.CurrentValue;
        _formRepository = formRepository;
        _iRatingFactorsRepository = iRatingFactorsRepository;
        _formEligibilityRepository = formEligibilityRepository;
        _lookupRepository = lookupRepository;
        _limitRetentionFactorRepository = limitRetentionFactorRepository;
        _occLimitFactorRepository = occLimitFactorRepository;
        _projectTypeFactorRepository = projectTypeFactorRepository;
        _retainedValueFactorRepository = retainedValueFactorRepository;
        _retainedValueFactorMatrixRepository = retainedValueFactorMatrixRepository;
        _revenueBaseRateRepository = revenueBaseRateRepository;
        _lookupRepository= lookupRepository;
        _includedCoverageEnhancementsRepository = includedCoverageEnhancementsRepository;
        _optCovTable1Repository = optCovTable1Repository;
        _optionalCoverageTable1Repository = optionalCoverageTable1Repository;
    }


    public async Task<Result<RaterResult, RaterFailureDetails>> GetRateInformation(RaterInputs raterInputs)
    {
        _raterDetails.RaterInputs = raterInputs;

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
        if(!ValidateIndustryInformationExceed(raterInputs.IndustryClassifications!))
        {
            return new RaterFailureDetails("InvalidIndustryClassification", "Maximum 5 Industry Classifications are allowed.");
        }

        //var eligibleForms = await GetEligibileForms(_raterDetails.PrimaryIndustryClassification!.SpecialtyId!.Value);

        //Validate sum of exposure percentages
        if (!ValidateTotalExposure(_raterDetails))
        {
            return new RaterFailureDetails("InvalidExposurePercentages", "Exposures must sum to 100%.");
        }

        if (!ValidateOptionalEnhancements(raterInputs))
        {
            //Supported Optional Enhancements are : Crisis Management/Media activities
            return new RaterFailureDetails("InvalidOptionalEnhancements", "One or more optional enhancements are invalid.");
        }
        _raterDetails.Revenue = raterInputs.Revenue;

        AdditionalUWCalculation(raterInputs.AdditionalRiskProfile);

        await GetOptionalEnhancements();


        _raterDetails.PrimaryCoverage = GetPrimaryCoverage(raterInputs.Coverages!);

        if ((_raterDetails.PrimaryCoverage?.OccuranceLimit ?? 0m) != (_raterDetails?.Profile.EO_OccLimit ?? 0m))
        {
            _logger.LogWarning("OccuranceLimit ({0}) of Coverages in the request does not match with the Magic database ({1}).",
                                            _raterDetails?.PrimaryCoverage?.OccuranceLimit ?? 0m, decimal.Truncate(_raterDetails?.Profile.EO_OccLimit ?? 0m));
        }
        if ((_raterDetails?.PrimaryCoverage?.AggregateLimit ?? 0m) != (_raterDetails?.Profile.EO_AggLimit ?? 0m))
        {
            _logger.LogWarning("AggregateLimit ({0}) of Coverages in the request does not match with the Magic database ({1}).",
                                            _raterDetails?.PrimaryCoverage?.AggregateLimit ?? 0m, decimal.Truncate(_raterDetails?.Profile.EO_AggLimit ?? 0m));
        }
        if ((_raterDetails?.PrimaryCoverage?.Retention ?? 0m) != (_raterDetails?.Profile.EO_Retention ?? 0m))
        {
            _logger.LogWarning("Retention ({0}) of Coverages in the request does not match with the Magic database ({1}).",
                                            _raterDetails?.PrimaryCoverage?.Retention ?? 0m, decimal.Truncate(_raterDetails?.Profile.EO_Retention ?? 0m));
        }

        if (raterInputs.RatingFactorStep != null)
        {
            await SetRatingFactor(raterInputs.RatingFactorStep, _raterOptions.Version);
        }

        var crisisManagement = raterInputs.OptionalEnhancements?.FirstOrDefault(e => e.OptionalEnhancementName == "Crisis Management")?.OptionalEnhancementValue;
        var mediaActivities = raterInputs.OptionalEnhancements?.FirstOrDefault(e => e.OptionalEnhancementName == "Media activities")?.OptionalEnhancementValue;

        decimal crisisManagementValue = crisisManagement == "Full" ? _raterDetails?.PrimaryCoverage?.OccuranceLimit ?? 0m : Convert.ToDecimal(crisisManagement);
        decimal mediaActivitiesValue = mediaActivities == "Full" ? _raterDetails?.PrimaryCoverage?.OccuranceLimit ?? 0m : Convert.ToDecimal(mediaActivities);

        var premium = await CalculatePremium(_raterDetails?.PrimaryCoverage, raterInputs.AdditionalRiskProfile, crisisManagementValue, mediaActivitiesValue);
        
        var revnueChange = (_raterDetails?.Profile.Revenue - _raterDetails?.Profile.ExposureBase) * 100 / _raterDetails?.Profile.ExposureBase ?? 0m;
        var premiumChange = (premium - _raterDetails?.Profile.EO_GWP ?? 0m) * 100 / _raterDetails?.Profile.EO_GWP ?? 0m;

        //var rateChange = CalculateRateChange(); // TODO: Only upcomingTermTotalPremium and projectSpecificXSLimitFactor calculation logic still needs to be implemented. Hardcoded for now.
        var rateChange = await CalculateRateChange(_raterDetails?.Profile, _raterDetails?.PrimaryCoverage, premium);

        _raterDetails?.RevenueChange = revnueChange;
        _raterDetails?.PremiumChange = premiumChange;
        _raterDetails?.RateChange = rateChange;

        return new RaterResult()
        {
            RaterVersion = _raterOptions.Version,
            RaterVersionDate = _raterOptions.VersionDate,
            OccuranceLimit = _raterDetails?.PrimaryCoverage?.OccuranceLimit ?? 0m,
            AggregateLimit = _raterDetails?.PrimaryCoverage?.AggregateLimit ?? 0m,
            Retention = _raterDetails?.PrimaryCoverage?.Retention ?? 0m,
            ExpiringPremium = _raterDetails?.Profile.EO_GWP ?? 0m,
            RenewalPremium = premium,
            RevenueChange = revnueChange,
            PremiumChange = premiumChange,
            RateChange = rateChange
        };
    }

    private static bool ValidateIndustryInformationExceed(List<IndustryClassification> industryClassifications)
    {
        return industryClassifications.Count <= 5;
    }

    private Dictionary<string, string> LoadIndustryNameToAlternativeExposureBaseMap()
    {
        var industryNameToAlternativeExposureBaseMap = new Dictionary<string, string>(); // { { "Architectural Services", "Not applicable"} }; This industry key is not present in the table so it should return "Not applicable".

        _raterDetails.IndustryNameToAlternativeExposureBaseMap = industryNameToAlternativeExposureBaseMap;

        return industryNameToAlternativeExposureBaseMap;
    }

    private List<BaseRateTablesTable1> LoadBaseRateTablesTable1Records()
    {
        var baseRateTablesTable1Records = new List<BaseRateTablesTable1>() { new() { Revenue = 0m, BaseRateEAndO = 350 },
                                                                             new() { Revenue = 25000m, BaseRateEAndO = 354 },
                                                                             new() { Revenue = 50000m, BaseRateEAndO = 388 },
                                                                             new() { Revenue = 75000m, BaseRateEAndO = 444 },
                                                                             new() { Revenue = 100000m, BaseRateEAndO = 513 } };

        //baseRateTablesTable1Records.Sort();

        _raterDetails.BaseRateTablesTable1Records = baseRateTablesTable1Records;

        return baseRateTablesTable1Records;
    }

    private List<RatingTablesTable1> LoadRatingTablesTable1Records()
    {
        var ratingTablesTable1Records = new List<RatingTablesTable1>() { new() { LimitOrRetentionOption = 0m, EAndOLow = -0.1879m,  EAndOMedium = -0.1879m },
                                                                         new() { LimitOrRetentionOption = 1000m, EAndOLow = -0.1135m,  EAndOMedium = -0.1135m },
                                                                         new() { LimitOrRetentionOption = 2500m, EAndOLow = -0.0804m, EAndOMedium = -0.0804m },
                                                                         new() { LimitOrRetentionOption = 5000m, EAndOLow = -0.0449m, EAndOMedium = -0.0449m },
                                                                         new() { LimitOrRetentionOption = 10000m, EAndOLow = 0m, EAndOMedium = 0m },
                                                                         // ...
                                                                         new() { LimitOrRetentionOption = 1000000m, EAndOLow = 0.993256614378974m,  EAndOMedium = 0.993256614378974m },
                                                                         new() { LimitOrRetentionOption = 1500000m, EAndOLow = 1.30858977343551m,  EAndOMedium = 1.30858977343551m }, };

        //ratingTablesTable1Records.Sort();

        _raterDetails.RatingTablesTable1Records = ratingTablesTable1Records;

        return ratingTablesTable1Records;
    }

    private List<RatingTablesTable2> LoadRatingTablesTable2Records()
    {
        var ratingTablesTable2Records = new List<RatingTablesTable2>() { new() { RetainedValue = 1m, FactorEAndO = 1m },
                                                                         new() { RetainedValue = 1.2m, FactorEAndO = 1.021m },
                                                                         new() { RetainedValue = 1.4m, FactorEAndO = 1.044m },
                                                                         // ...
                                                                         new() { RetainedValue = 2.0m, FactorEAndO = 1.097m },
                                                                         new() { RetainedValue = 2.2m, FactorEAndO = 1.111m },
                                                                         // ...
                                                                         new() { RetainedValue = 3m, FactorEAndO = 1.157m },        // The FactorEAndO is calculated through a formula and has more digits after decimal point in the table.
                                                                         new() { RetainedValue = 3.2m, FactorEAndO = 1.166m }, };

        //ratingTablesTable2Records.Sort();

        _raterDetails.RatingTablesTable2Records = ratingTablesTable2Records;

        return ratingTablesTable2Records;
    }

    private List<RatingTablesTable3> LoadRatingTablesTable3Records()
    {
        var ratingTablesTable3Records = new List<RatingTablesTable3>() { new() { RetainedValue = 0m, Factor = 0.9205m },
                                                                         new() { RetainedValue = 0.05m, Factor = 0.9240m },
                                                                         new() { RetainedValue = 0.1m, Factor = 0.9276m },
                                                                         // ...
                                                                         new() { RetainedValue = 0.95m, Factor = 0.9875m },
                                                                         new() { RetainedValue = 1m, Factor = 1m },
                                                                         new() { RetainedValue = 10m, Factor = 1m } };

        //ratingTablesTable3Records.Sort();

        _raterDetails.RatingTablesTable3Records = ratingTablesTable3Records;

        return ratingTablesTable3Records;
    }

    private decimal CalculateRateChange()
    {
        LoadIndustryNameToAlternativeExposureBaseMap();
        LoadBaseRateTablesTable1Records();
        LoadRatingTablesTable1Records();
        LoadRatingTablesTable2Records();
        LoadRatingTablesTable3Records();

        var priorTermTotalPremium = _raterDetails?.Profile?.EO_GWP;

        var upcomingTermTotalPremium = _raterDetails?.Premium; // TODO: Assuming the UpcomingTermTotalPremium is the premium being calculated in sheet 5. If it is not it should be updated with the formula in the excel.

        #region UpcomingTermBaseRates

        var industry = _raterDetails?.PrimaryIndustryClassification?.SpecialtyName ?? "";
        var alternativeExposureBase = _raterDetails?.IndustryNameToAlternativeExposureBaseMap?.ContainsKey(industry) == true ? _raterDetails?.IndustryNameToAlternativeExposureBaseMap?[industry] : "Not applicable";
        decimal? alternativeExposureValue = null; //TODO: There is a formula for this. This is not in Design Professional Flow.
        var constructionValueRequired = _raterDetails?.PrimaryIndustryClassification?.SubSectorName == "General Contractors" || _raterDetails?.PrimaryIndustryClassification?.SubSectorName == "Subcontractors" || _raterDetails?.PrimaryIndustryClassification?.SubSectorName == "Manufacturing";
        decimal? upcomingTermExposure;

        if (alternativeExposureBase == "Not applicable" || industry == "Property Management - Standalone" || constructionValueRequired) // TODO: Looks like industry cell reference refers to the Specialty selected but not 100% sure For now assuming it is specialty.
        {
            upcomingTermExposure = _raterDetails?.RevenueAdjusted;
        }
        else if (alternativeExposureBase == "Revenue - Creatives")
        {
            upcomingTermExposure = _raterDetails?.Revenue;
        }
        else
        {
            upcomingTermExposure = alternativeExposureValue;
        }
        
        var upcomingTermExposureMatchingRecordLow = _raterDetails?.BaseRateTablesTable1Records?.LastOrDefault<BaseRateTablesTable1>(brtr => brtr.Revenue <= upcomingTermExposure); // List is sorted.
        var upcomingTermExposureMatchingRecordHigh = _raterDetails?.BaseRateTablesTable1Records?.SkipWhile<BaseRateTablesTable1>(brtr => brtr != upcomingTermExposureMatchingRecordLow).Skip(1).FirstOrDefault();
        var upcomingTermExposureHighValue = upcomingTermExposureMatchingRecordHigh?.Revenue;
        var upcomingTermExposureLowValue = upcomingTermExposureMatchingRecordLow?.Revenue;
        var upcomingTermExposureHighCoefficient = upcomingTermExposureMatchingRecordHigh?.BaseRateEAndO;
        var upcomingTermExposureLowCoefficient = upcomingTermExposureMatchingRecordLow?.BaseRateEAndO;
        var upcomingTermBaseRates = (upcomingTermExposure - upcomingTermExposureLowValue) / (upcomingTermExposureHighValue - upcomingTermExposureLowValue) * upcomingTermExposureHighCoefficient
                                    + (1 - (upcomingTermExposure - upcomingTermExposureLowValue) / (upcomingTermExposureHighValue - upcomingTermExposureLowValue)) * upcomingTermExposureLowCoefficient;

        #endregion UpcomingTermBaseRates

        #region PriorTermBaseRates

        var priorTermExposure = _raterDetails?.Profile?.ExposureBase;
        var priorTermExposureMatchingRecordLow = _raterDetails?.BaseRateTablesTable1Records?.LastOrDefault<BaseRateTablesTable1>(brtr => brtr.Revenue <= priorTermExposure); // List is sorted.
        var priorTermExposureMatchingRecordHigh = _raterDetails?.BaseRateTablesTable1Records?.SkipWhile<BaseRateTablesTable1>(brtr => brtr != priorTermExposureMatchingRecordLow).Skip(1).FirstOrDefault();
        var priorTermExposureHighValue = priorTermExposureMatchingRecordHigh?.Revenue;
        var priorTermExposureLowValue = priorTermExposureMatchingRecordLow?.Revenue;
        var priorTermExposureHighCoefficient = priorTermExposureMatchingRecordHigh?.BaseRateEAndO;
        var priorTermExposureLowCoefficient = priorTermExposureMatchingRecordLow?.BaseRateEAndO;
        var priorTermBaseRates = (priorTermExposure - priorTermExposureLowValue) / (priorTermExposureHighValue - priorTermExposureLowValue) * priorTermExposureHighCoefficient
                                 + (1 - (priorTermExposure - priorTermExposureLowValue) / (priorTermExposureHighValue - priorTermExposureLowValue)) * priorTermExposureLowCoefficient;

        #endregion PriorTermBaseRates

        var upcomingTermLimitFactor = _raterDetails?.UpcomingTermLimitFactor;


        #region PriorTermLimitFactor

        #region LimitRetentionFactor

        // W21
        var retention = _raterDetails?.PrimaryCoverage?.Retention;
        var retentionMatchingRecordLow = _raterDetails?.RatingTablesTable1Records?.LastOrDefault<RatingTablesTable1>(rtr => rtr.LimitOrRetentionOption <= retention); // List is sorted.
        var retentionMatchingRecordHigh = _raterDetails?.RatingTablesTable1Records?.SkipWhile<RatingTablesTable1>(rtr => rtr != retentionMatchingRecordLow).Skip(1).FirstOrDefault();

        // W324
        var retentionLowValue = retentionMatchingRecordLow?.LimitOrRetentionOption;
        // W325
        var retentionHighValue = retentionMatchingRecordHigh?.LimitOrRetentionOption;
        // W329
        var retentionLowCoefficient = retentionMatchingRecordLow?.EAndOMedium;
        // W330
        var retentionHighCoefficient = retentionMatchingRecordHigh?.EAndOMedium;

        //W322
        var occurrenceRetentionSum = _raterDetails?.PrimaryCoverage?.Retention + _raterDetails?.PrimaryCoverage?.OccuranceLimit;
        var occurrenceRetentionSumMatchingRecordLow = _raterDetails?.RatingTablesTable1Records?.LastOrDefault<RatingTablesTable1>(rtr => rtr.LimitOrRetentionOption <= occurrenceRetentionSum); // List is sorted.
        var occurrenceRetentionSumMatchingRecordHigh = _raterDetails?.RatingTablesTable1Records?.SkipWhile<RatingTablesTable1>(rtr => rtr != occurrenceRetentionSumMatchingRecordLow).Skip(1).FirstOrDefault();

        // W326
        var occurrenceRetentionSumLowValue = occurrenceRetentionSumMatchingRecordLow?.LimitOrRetentionOption;
        // W327
        var occurrenceRetentionSumHighValue = occurrenceRetentionSumMatchingRecordHigh?.LimitOrRetentionOption;
        // W331
        var occurrenceRetentionSumLowCoefficient = occurrenceRetentionSumMatchingRecordLow?.EAndOMedium;
        // W332
        var occurrenceRetentionSumHighCoefficient = occurrenceRetentionSumMatchingRecordHigh?.EAndOMedium;

        // W334 - = (W321 - W324) / (W325 - W324) * W330 + (1 - (W321 - W324) / (W325 - W324)) * W329
        var retentionWeightedCoefficient = (retention - retentionLowValue) / (retentionHighValue - retentionLowValue) * retentionHighCoefficient
                                           + (1 - (retention - retentionLowValue) / (retentionHighValue - retentionLowValue)) * retentionLowCoefficient;

        // W335 - = (W322 - W326) / (W327 - W326) * W332 + (1 - (W322 - W326) / (W327 - W326)) * W331
        var occurrenceRetentionSumWeightedCoefficient = (occurrenceRetentionSum - occurrenceRetentionSumLowValue) / (occurrenceRetentionSumHighValue - occurrenceRetentionSumLowValue) * occurrenceRetentionSumHighCoefficient
                                                       + (1 - (occurrenceRetentionSum - occurrenceRetentionSumLowValue) / (occurrenceRetentionSumHighValue - occurrenceRetentionSumLowValue)) * occurrenceRetentionSumLowCoefficient;

        // Calculations!W336 - Limit Retention Factor - Formula - =W335-W334
        var limitRetentionFactor = occurrenceRetentionSumWeightedCoefficient - retentionWeightedCoefficient;

        #endregion LimitRetentionFactor

        #region SplitLimitFactor

        // W311
        var perClaim = _raterDetails?.PrimaryCoverage?.OccuranceLimit;
        // X311
        var aggregate = _raterDetails?.PrimaryCoverage?.AggregateLimit;

        //W340
        var splitLimitFactorRetainedValue = 1 + (aggregate - perClaim) / perClaim;
        var splitLimitFactorRetainedValueMatchingRecordLow = _raterDetails?.RatingTablesTable2Records?.LastOrDefault<RatingTablesTable2>(rtr => rtr.RetainedValue <= splitLimitFactorRetainedValue); // List is sorted.
        var splitLimitFactorRetainedValueMatchingRecordHigh = _raterDetails?.RatingTablesTable2Records?.SkipWhile<RatingTablesTable2>(rtr => rtr != splitLimitFactorRetainedValueMatchingRecordLow).Skip(1).FirstOrDefault();

        // W341
        var splitLimitFactorLowValue = splitLimitFactorRetainedValueMatchingRecordLow?.RetainedValue;

        // W342
        var splitLimitFactorHighValue = splitLimitFactorRetainedValueMatchingRecordHigh?.RetainedValue;

        // W344
        var splitLimitFactorLowCoefficient = splitLimitFactorRetainedValueMatchingRecordLow?.FactorEAndO;

        // W345
        var splitLimitFactorHighCoefficient = splitLimitFactorRetainedValueMatchingRecordHigh?.FactorEAndO;

        // W347 - Split Limit Factor -Formula - = (W$340 - W341)/ (W342 - W341) * W345 + (1 - (W$340 - W341)/ (W342 - W341))*W344
        var splitLimitFactor = (splitLimitFactorRetainedValue - splitLimitFactorLowValue) / (splitLimitFactorHighValue - splitLimitFactorLowValue) * splitLimitFactorHighCoefficient
                               + (1 - (splitLimitFactorRetainedValue - splitLimitFactorLowValue) / (splitLimitFactorHighValue - splitLimitFactorLowValue)) * splitLimitFactorLowCoefficient;

        #endregion SplitLimitFactor

        #region SharedLimit

        // W349
        var sharedLim = _raterDetails?.PrimaryCoverage?.AggregateLimit;

        var aggLimit = _raterDetails?.RaterInputs?.Coverages?.Select(c => c.AggregateLimit).Max();

        var coversSharing = _raterDetails?.RaterInputs?.Coverages?.Count(c => c.AggregateLimit > 0);

        // W350
        var adjustedLimit = aggLimit / coversSharing;

        // W351
        decimal? sharedLimitRetainedValue;

        if (sharedLim == 0)
        {
            sharedLimitRetainedValue = 1;
        }
        else
        {
            sharedLimitRetainedValue = 1 + (adjustedLimit - sharedLim) / sharedLim;
        }

        var sharedLimitRetainedValueMatchingRecordLow = _raterDetails?.RatingTablesTable3Records?.LastOrDefault<RatingTablesTable3>(rtr => rtr.RetainedValue <= sharedLimitRetainedValue); // List is sorted.
        var sharedLimitRetainedValueMatchingRecordHigh = _raterDetails?.RatingTablesTable3Records?[(_raterDetails?.RatingTablesTable3Records?.IndexOf(sharedLimitRetainedValueMatchingRecordLow!) ?? 0) + 1];

        // W352
        var sharedLimitLowValue = sharedLimitRetainedValueMatchingRecordLow?.RetainedValue;

        // W353
        var sharedLimitHighValue = sharedLimitRetainedValueMatchingRecordHigh?.RetainedValue;

        // W355
        var sharedLimitLowCoefficient = sharedLimitRetainedValueMatchingRecordLow?.Factor;

        // W356
        var sharedLimitHighCoefficient = sharedLimitRetainedValueMatchingRecordHigh?.Factor;

        // W358 - Shared Limit - Formula - = (W351 - W352) / (W353 - W352) * (W356 - W355) + W355
        var sharedLimit = (sharedLimitRetainedValue - sharedLimitLowValue) / (sharedLimitHighValue - sharedLimitLowValue) * (sharedLimitHighCoefficient - sharedLimitLowCoefficient) + sharedLimitLowCoefficient;

        #endregion SharedLimit

        #region ProjectSpecificXSLimitFactor

        // W360 - Project Specific XS Limit Factor -Formula - = Project_type!E299
        var projectSpecificXSLimitFactor = 1m; // TODO: Calculation yet to be done from the formula. For now hardcoded to value coming for our flow.

        #endregion ProjectSpecificXSLimitFactor

        var priorTermLimitFactor = limitRetentionFactor * splitLimitFactor * sharedLimit * projectSpecificXSLimitFactor;

        #endregion PriorTermLimitFactor

        // 
        var upcomingTermLimitAdjustedPremium = upcomingTermTotalPremium / upcomingTermBaseRates * priorTermBaseRates / upcomingTermLimitFactor * priorTermLimitFactor;

        var rateChange = (upcomingTermLimitAdjustedPremium / priorTermTotalPremium - 1) * 100;
        return rateChange ?? 0m;
    }

    private static bool ValidateOptionalEnhancements(RaterInputs raterInputs)
    {
        //TODO:Below values are from OptCov Sheet (from both B67:B77 and Q67:Q76)
        List<string> optionalEnhancements =
        [
            "Crisis Management",
            "Media activities",
            "Contractors Pollution (Claims Made)",
            "Contractors Pollution (Occ)",
            "Defense Outside Limits",
            "Rectification Expenses",
            "Aggregate limit endorsement",
            "First Dollar Defense",
            "Waiver of subrogation",
            "Worldwide Coverage Territory",
            "Additional Insured",
            "Bodily Injury",
            "Property Damage",
            "Personal & Advertising Injury",
            "Third Party Discrimination",
            "Protective Indemnity",
            "Pollutants in Transit",
            "Non-Owned Disposal Site",
            "Failure to disclose pollutants",
            "Pollution liability",
            "Technology Coverage Extension",
            "Network security & privacy",
        ];
        if (raterInputs?.OptionalEnhancements?.Any(e => !optionalEnhancements.Contains(e.OptionalEnhancementName ?? "")) == true)
        {
             return false;
            
        }
        return true;
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
    internal async Task<List<string>> LoadIncludedCoverageEnhancementsAsync()
    {
        //TODO:FIll IncludedCoverageEnhancements in RaterDetails based on FormChosen which will have list of coverages which is included in the coverage.
        //This info is from the Other_lookup sheet (Table name - form_info_lkup) column AU.
        //List<string> includedCoverageEnhancements = (await _includedCoverageEnhancementsRepository.GetByForm(_raterOptions.Version,"Form Chosen")).ToList();
        List<string> includedCoverageEnhancements = new List<string>() { "Property Damage(full limit)",            
                                                                         "Bodily Injury(full limit)", 
                                                                         "Pollution Liability(full limit)", 
                                                                         "Third Party Discrimination(full Limit)", 
                                                                         "Personal & Advertising Injury",
                                                                         "Crisis Management", 
                                                                         "Media activities",
                                                                         "Defense of Licensing Proceedings", 
                                                                         "FHA / OSHA / ADA regulatory proceedings",
                                                                         "Pre - claim assistance", 
                                                                         "Subpoena assistance", 
                                                                         "Supplemental payments" };
        _raterDetails.IncludedCoverageEnhancements = includedCoverageEnhancements;
        return includedCoverageEnhancements;
    }
    internal async Task<List<OptCovTable1>> LoadOptCovTable1Async()
    {
        //TODO: The values to be filled from OptCov Sheet from Range or table from (B8 to E58)
        //_raterDetails.OptCovTable1Records = (List<OptCovTable1>?)await _optCovTable1Repository.GetAll(_raterOptions.Version);
         _raterDetails.OptCovTable1Records = new List<OptCovTable1>() { 
             new() {Version="", Id = 0, OptionalCoverage = "Crisis Management", ApplicableToCoverageOrGTC = "Coverage", ApplicableToFormOrEndorsement =  "Form", ENumber = ""} ,
             new() {Version="", Id = 0, OptionalCoverage = "Media activities", ApplicableToCoverageOrGTC = "Coverage", ApplicableToFormOrEndorsement = "Form", ENumber = ""} };
        return _raterDetails.OptCovTable1Records;
    }
    internal async Task<List<OptionalCoveragesTable1>> LoadOptionalCoveragesTable1Async()
    {
        //TODO: The values to be filled from Optional_CoveragesTable Sheet from Range or table from (C7 to M65)
        //_raterDetails.OptionalCoveragesTable1Records = (List<OptionalCoveragesTable1>?)await _optionalCoverageTable1Repository.GetAll(_raterOptions.Version);
        _raterDetails.OptionalCoveragesTable1Records = new List<OptionalCoveragesTable1>() {
             new() {Version="", Id = 0, OptionalAdditionalCoverage = "Crisis Management", ValueOfInsurance = 1.97m, Premium = 45} ,
             new OptionalCoveragesTable1() {Version="", Id = 0, OptionalAdditionalCoverage = "Media activities", ValueOfInsurance = 10.53m, Premium = 243} };
        return _raterDetails.OptionalCoveragesTable1Records;
    }
    internal Dictionary<string, string> LoadOptionalCoverageNameToDefaultAmountMap()
    {
        _raterDetails.OptionalCoverageNameToDefaultAmountMap = new Dictionary<string, string>()
                                                                {{ "Crisis Management", "50000" },{"Media activities", "Full"}};
        //TODO:Default amount to be fetched from D67 onwards in OptCov Sheet.
        return _raterDetails.OptionalCoverageNameToDefaultAmountMap;
    }
    internal Dictionary<string, string> LoadOptionalCoverageNameToDataValidationMap()
    {
        _raterDetails.OptionalCoverageNameToDataValidationMap = new Dictionary<string, string>()
                                                                {{ "Crisis Management", "Vol" },{"Mediact Aivities", "Vol"}};
        //TODO:DataValidation(AOE/Vol etc.) to be fetched from AW7 to AX58 range in OptCov Sheet.

        return _raterDetails.OptionalCoverageNameToDataValidationMap;
    }
    internal Dictionary<string, string> LoadOptionalCoverageToDifferentialMap()
    {
        _raterDetails.OptionalCoverageToDifferentialMap = new Dictionary<string, string>()
                                                                {{ "Crisis Management", "0% / $0" },{"Media activities", "0% / $0"}};
        //TODO:Differential to be fetched from C276 to R335 range in Optional_Coverages Sheet.

        return _raterDetails.OptionalCoverageToDifferentialMap;
    }
    internal async Task GetOptionalEnhancements()
    {
        await LoadIncludedCoverageEnhancementsAsync();
        await LoadOptCovTable1Async();
        LoadOptionalCoverageNameToDefaultAmountMap();
        await LoadOptionalCoveragesTable1Async();
        LoadOptionalCoverageToDifferentialMap();

        foreach (var optionalEnhancement in _raterDetails?.RaterInputs?.OptionalEnhancements ?? Enumerable.Empty<OptionalEnhancement>())
        {
            var matchingOptCovRecord = _raterDetails?.OptCovTable1Records?.FirstOrDefault(r => r.OptionalCoverage == optionalEnhancement?.OptionalEnhancementName?.ToString());
            var matchingOptionalCoverageRecord = _raterDetails?.OptionalCoveragesTable1Records?.FirstOrDefault(r => r.OptionalAdditionalCoverage == optionalEnhancement?.OptionalEnhancementName?.ToString());


            //Formula for Applicable To is : -	=IFERROR(IF(IA16="Yes", IF(VLOOKUP($HY16,OptCov!$B$8:$E$58,4,FALSE)="Coverage","Base","GTC"), ""),"")
            if (matchingOptCovRecord?.ApplicableToCoverageOrGTC == "Coverage")
            {
                optionalEnhancement.ApplicableTo = "Base";
            }
            else
            {
                optionalEnhancement.ApplicableTo = "GTC";

            }

            //Formula for Version is : - =IF(OR(HY16="",IA16<>"Yes"),"",IF(VLOOKUP(HY16,OptCov!$B$8:$T$58,16,FALSE)="Endorsement",VLOOKUP(HY16,OptCov!$B$8:$T$58,17,FALSE),
            //                                          IF(IC16=VLOOKUP(Rater!HY16,OptCov!$B$67:$G$93,3,FALSE),"Included coverage enhancement","Modified coverage enhancement")))
            if(matchingOptCovRecord?.ApplicableToFormOrEndorsement == "Endorsment")
            {
                optionalEnhancement.Version = matchingOptCovRecord?.ENumber;
            }
            else if (optionalEnhancement.OptionalEnhancementValue?.ToString() == _raterDetails?.OptionalCoverageNameToDefaultAmountMap?[optionalEnhancement?.OptionalEnhancementName?.ToString() ?? ""])//TODO:Need to handle Comma in the decimal value.
            {
                optionalEnhancement?.Version = "Included coverage enhancement";
            }
            else
            {
                optionalEnhancement?.Version = "Modified coverage enhancement";
            }
            //Formula for percentage is : -	-	=IFERROR(IF(IA16="Yes", IF(AND(IF16<>"Modified coverage enhancement", IF16<>"Included coverage enhancement"),
            //                                  IF(IL16="AOE", TEXT(VLOOKUP(HY16,Optional_coverages!$C$7:$L$65,10,FALSE), "$#,##0"),
            //                                  TEXT(VLOOKUP(HY16,Optional_coverages!$C$7:$L$65,10,FALSE), "0%") & " / " & TEXT(VLOOKUP(HY16,Optional_coverages!$C$7:$M$65,11,FALSE), "$#,##0")),
            //                                  INDEX(Optional_coverages!$R$276:$R$335, MATCH(Rater!HY16, Optional_coverages!$C$276:$C$335, 0))),""), "")
            //TODO: Need to fetch the data from Table C7 to L65 in "Optional_coverages" sheet.

         
            if(optionalEnhancement?.Version != "Included coverage enhancement" && optionalEnhancement?.Version != "Modified coverage enhancement")
            {
                if (_raterDetails?.OptionalCoverageNameToDataValidationMap?[optionalEnhancement?.OptionalEnhancementName?.ToString() ?? ""] == "AOE")
                {
                    optionalEnhancement?.Percentage = $"{matchingOptionalCoverageRecord?.ValueOfInsurance:$#,##0}";
                }
                else
                {
                    optionalEnhancement?.Percentage = $"{matchingOptionalCoverageRecord?.ValueOfInsurance:$0%}" + " / " + 
                                                     $"{matchingOptionalCoverageRecord?.Premium:$#,##0}";
                }
            }
            else
            {
                optionalEnhancement.Percentage = _raterDetails?.OptionalCoverageToDifferentialMap?[optionalEnhancement?.OptionalEnhancementName?.ToString() ?? ""];
            }
            

        }
        //Option2 and Option3 is not part of Design Professional workflow.
        //Option1 is filled from profile tab.
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

        worksheet.IndustryClassifications = [.. industryClassifications.OrderByDescending(x => x.PercentageExposure).Take(5)];
        worksheet.PrimaryIndustryClassification = worksheet.IndustryClassifications[0];//Assuming the first value as Primary Industry info
        worksheet.AdditionalIndustryClassifications = [.. worksheet.IndustryClassifications.Skip(1)];

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
    private async Task SetRatingFactor(RatingFactor ratingFactor, string version)
    {
        await CalculateClaimHistory(ratingFactor, version);
        await CalculateRiskProfile(ratingFactor, version);
        await SetComplexityOfRiskRatingFactorDetails(ratingFactor);
    }
    /// <summary>
    /// Calculates factor, range, degree of concern for Complexity Of Risk section
    /// </summary>
    /// <param name="ratingFactor"></param>
    /// <returns></returns>
    private async Task SetComplexityOfRiskRatingFactorDetails(RatingFactor ratingFactor)
    {
        _raterDetails.RatingFactorStep ??= new RatingFactor();
        _raterDetails.RatingFactorStep.ComplexityOfRiskRatingFactorDetails = ratingFactor.ComplexityOfRiskRatingFactorDetails;
        _raterDetails.RatingFactorStep?.ComplexityOfRiskRatingFactorDetails?.Factor = ratingFactor.ComplexityOfRiskRatingFactorDetails?.Factor ?? 0;
        if (ratingFactor.ComplexityOfRiskRatingFactorDetails?.Factor == 1)
        {
            _raterDetails.RatingFactorStep?.ComplexityOfRiskRatingFactorDetails?.DegreeOfConcern= "Comfortable";
            _raterDetails.RatingFactorStep?.ComplexityOfRiskRatingFactorDetails?.Range = "0.95 - 1.05";
        }
    }
    /// <summary>
    /// Calculates factor, range, degree of concern for Claim History section
    /// </summary>
    /// <param name="ratingFactor"></param>
    /// <param name="version"></param>
    /// <returns></returns>
    private async Task CalculateClaimHistory(RatingFactor ratingFactor, string version)
    {
        RatingFactorMaster? ratingFactorMaster;

        if (ratingFactor.ClaimHistoryQuestions == 0)
        {
            ratingFactorMaster = new RatingFactorMaster()
            {
                Version = _raterOptions.Version,
                Low = _defaultRatingFactor,
                High = _defaultRatingFactor,
                Factor = _defaultRatingFactor,
                DegreeOfConcern = "Comfortable",
            };
        }
        else
        {
            ratingFactorMaster = await _iRatingFactorsRepository.GetRatingFactorByQuestion(version,
                                                                    (short)RatingFactorSectionType.ClaimHistory,
                                                                    (short)ratingFactor.ClaimHistoryQuestions);
        }

        _raterDetails.RatingFactorStep ??= new RatingFactor();
        var range = string.Empty;

        if (ratingFactorMaster != null)
        {
            if ((ratingFactorMaster?.Factor ?? _defaultRatingFactor) == 3.5m)
            {
                range = "3.50 - no cap";
            }
            else
            {
                range = (ratingFactorMaster?.Low == _defaultRatingFactor && ratingFactorMaster.High == _defaultRatingFactor) ? $"{_defaultRatingFactor}"
                                                                                    : $"{ratingFactorMaster?.Low} - {ratingFactorMaster?.High}";
            }
            _raterDetails.RatingFactorStep.ClaimHistoryRatingFactorDetails = new RatingFactorSectionDetails
            {
                Range = range,
                Factor = ratingFactorMaster?.Factor ?? _defaultRatingFactor,
                DegreeOfConcern = ratingFactorMaster?.DegreeOfConcern ?? string.Empty,
                Suggested = ratingFactorMaster?.Factor ?? _defaultRatingFactor
            };
        }
    }
    /// <summary>
    /// Calculates factor, range, degree of concern for Risk profile section
    /// </summary>
    /// <param name="ratingFactor"></param>
    /// <param name="version"></param>
    /// <returns></returns>
    private async Task CalculateRiskProfile(RatingFactor ratingFactor, string version)
    {
        List<RatingFactorMaster> ratingFactorList = new List<RatingFactorMaster>();
        RatingFactorMaster? calculatedRatingFactor;

        if (ratingFactor.RiskProfileQuestions != null && ratingFactor.RiskProfileQuestions.Any())
        {
            ratingFactorList = await _iRatingFactorsRepository.GetRatingFactorBySection(version,
                                                                        (short)RatingFactorSectionType.RiskManagement);
        }

        int noAnswerOccurances = 0;
        if (ratingFactor.RiskProfileQuestions != null)
        {
            noAnswerOccurances = ratingFactor.RiskProfileQuestions.Count(x => x.Value == false);
        }

        if (noAnswerOccurances > 0)
        {
            calculatedRatingFactor = ratingFactorList
                                        .Where(x => !x.Answer)
                                        .OrderBy(x => x.QuestionId)
                                        .ElementAtOrDefault(noAnswerOccurances - 1);
        }
        else
        {
            int yesAnswerOccurances = 0;
            if (ratingFactor.RiskProfileQuestions != null)
            {
                yesAnswerOccurances = ratingFactor.RiskProfileQuestions!.Count(x => x.Value == true);
            }

            if (yesAnswerOccurances > 0)
            {
                calculatedRatingFactor = ratingFactorList
                                            .Where(x => x.Answer)
                                            .OrderBy(x => x.QuestionId)
                                            .ElementAtOrDefault(yesAnswerOccurances - 1);
            }
            else
            {
                calculatedRatingFactor = new RatingFactorMaster()
                {
                    Version = _raterOptions.Version,
                    Factor = _defaultRatingFactor,
                    Low = _defaultRatingFactor,
                    High = _defaultRatingFactor,
                    DegreeOfConcern = "Average",
                };
            }
        }

        _raterDetails.RatingFactorStep ??= new RatingFactor();

        if (calculatedRatingFactor != null)
        {
            _raterDetails.RatingFactorStep.RiskProfileRatingFactorDetails = new RatingFactorSectionDetails
            {
                Range = (calculatedRatingFactor.Low == _defaultRatingFactor
                                                    && calculatedRatingFactor.High == _defaultRatingFactor)
                                                    ? $"{_defaultRatingFactor}"
                                                    : $"{calculatedRatingFactor.Low} - {calculatedRatingFactor.High}",
                Factor = calculatedRatingFactor?.Factor ?? _defaultRatingFactor,
                DegreeOfConcern = calculatedRatingFactor?.DegreeOfConcern ?? string.Empty,
                Suggested = calculatedRatingFactor?.Factor ?? _defaultRatingFactor
            };
        }
    }
    /// <summary>
    /// Calculates premium that will be sent to response
    /// </summary>
    /// <param name="coverage"></param>
    /// <param name="additionalRiskProfile"></param>
    /// <param name="crisisManagerMent"></param>
    /// <param name="mediaActivities"></param>
    /// <returns>Premuim</returns>
    private async Task<decimal> CalculatePremium(Coverage? coverage, AdditionalRiskProfile? additionalRiskProfile, decimal crisisManagerMent, decimal mediaActivities)
    {
        // L13 in OptioinalCoverage excel sheet
        const decimal optionalCoreCoverageFactor = 35.5m;
        var perpcentContractorsPolution = -15.79m;
        var occrLimit = coverage?.OccuranceLimit ?? 0m;
        var aggrLimit = coverage?.AggregateLimit ?? 0m;
        decimal technologyCoverage = occrLimit;

        var optionalCoverages = await _occLimitFactorRepository.GetAll(_raterOptions.Version);

        int percentageCrisisManagerMent = (int)Math.Round((crisisManagerMent / occrLimit * 100), MidpointRounding.AwayFromZero);
        int percentageMediaActivities = (int)Math.Round((mediaActivities / occrLimit * 100), MidpointRounding.AwayFromZero);
        int percentageTechnologyCoverage = (int)Math.Round((technologyCoverage / occrLimit * 100), MidpointRounding.AwayFromZero);

        var forInsuranceCrisisManagerMent = optionalCoverages.Where(x => x.PercentOfOccLimit <= percentageCrisisManagerMent).OrderByDescending(x => x.PercentOfOccLimit).FirstOrDefault();

        var forInsurancemediaActivities = optionalCoverages.Where(x => x.PercentOfOccLimit <= percentageMediaActivities).OrderByDescending(x => x.PercentOfOccLimit).FirstOrDefault();

        var forTechnologyCoverage = optionalCoverages.Where(x => x.PercentOfOccLimit <= percentageTechnologyCoverage).OrderByDescending(x => x.TechnologyCoverageExtension).FirstOrDefault();

        //F255 in Calculations excel sheet
        var optionalCoverageFactor = optionalCoreCoverageFactor + forInsuranceCrisisManagerMent?.CrisisManagement + forInsurancemediaActivities?.MediaActivities + perpcentContractorsPolution + forTechnologyCoverage?.TechnologyCoverageExtension;

        //F102 in Calculations excel sheet
        var purePremiumSplit = 0.74m;

        //F153 in Calculations excel sheet
        decimal? baseRateForChosenExposure = await CalculateBaseRate(_raterDetails.Profile?.Revenue ?? 0m);
        _raterDetails.BaseRateForChosenExposure = baseRateForChosenExposure;

        //F198 in Calculations excel sheet
        decimal? limitFactor = await CalculateLimitFactor(occrLimit, aggrLimit, coverage?.Retention ?? 0m);
        _raterDetails.LimitFactor = limitFactor;

        //F245 in Calculations excel sheet
        var industryModifier = 3.49m;

        //F246 in Calculations excel sheet
        var geoGraphicModifier = await _geographicModRepository.GetAE(_raterOptions.Version, _raterDetails.Profile?.Zip ?? string.Empty);

        //F247 in Calculations excel sheet
        var formFactor = 1;

        var projectTypeFactor = await _projectTypeFactorRepository.GetAll(_raterOptions.Version);

        decimal totalRscf = 0;

        //F248 in Calculations excel sheet
        decimal? rscf = 0;

        if (additionalRiskProfile?.ProjectTypes != null)
        {
            totalRscf += projectTypeFactor
                        .Where(f => additionalRiskProfile.ProjectTypes.Contains(f.ProjectType))
                        .Sum(f => f.Factor);

            rscf = totalRscf / additionalRiskProfile?.ProjectTypes?.Count;
        }
        else
        {
            rscf = 0.8m;
        }

        //F250 in Calculations excel sheet
        var grandBasePremium = purePremiumSplit * baseRateForChosenExposure * limitFactor * industryModifier * geoGraphicModifier * formFactor * rscf;

        //F251 in Calculations excel sheet
        var basePremium = baseRateForChosenExposure * (1 - purePremiumSplit) * limitFactor;

        var var_exp_load = 0.25m;

        //F253 in Calculations excel sheet
        var premiumBeforeOptionalCoverage = (grandBasePremium + basePremium) / (1 - var_exp_load);

        var premium = formFactor * (premiumBeforeOptionalCoverage * (1 + (optionalCoverageFactor / 100)));
        _raterDetails.Premium = premium;

        return Math.Round(premium ?? 0, 2, MidpointRounding.AwayFromZero);
    }

    private async Task<decimal?> CalculateBaseRate(decimal revenueOrExposure)
    {
        var revenueBaseRate = await _revenueBaseRateRepository.GetAll(_raterOptions.Version);

        var baseRateRevenue = revenueBaseRate.Where(x => x.Revenue <= revenueOrExposure).OrderByDescending(x => x.Revenue).FirstOrDefault();

        //F138 in Calculations excel sheet
        var lowRevenueExposure = baseRateRevenue != null ? baseRateRevenue.Revenue : 0;

        //f140 in Calculations excel sheet
        var lowCoefRevenueExposure = baseRateRevenue != null ? baseRateRevenue.BaseRateEO : 0m;

        var baseRateCoef = revenueBaseRate.Where(x => x.Revenue > lowRevenueExposure).OrderBy(x => x.Revenue).FirstOrDefault();

        //F139 in Calculations excel sheet
        var highRevenueExposure = baseRateCoef != null ? baseRateCoef.Revenue : 0;

        //F141 in Calculations excel sheet
        var highCoefRevenueExposure = baseRateCoef != null ? baseRateCoef.BaseRateEO : 0m;

        return (revenueOrExposure - lowRevenueExposure) / (highRevenueExposure - lowRevenueExposure) * highCoefRevenueExposure + (1 - (revenueOrExposure - lowRevenueExposure) / (highRevenueExposure - lowRevenueExposure)) * lowCoefRevenueExposure;
    }

    /// <summary>
    /// Calculates Rate Change that will be sent to response
    /// </summary>
    /// <returns></returns>
    private async Task<decimal> CalculateRateChange(PolicyDetails? policyDetails, Coverage? coverage, decimal premium)
    {
        var priorBaseRate = await CalculateBaseRate(policyDetails?.ExposureBase ?? 0);

        var priorLimitFactor = await CalculateLimitFactor(policyDetails?.EO_OccLimit ?? 0m, policyDetails?.EO_AggLimit ?? 0m, policyDetails?.EO_Retention ?? 0m);

        var upcomingPriorBaseRate = await CalculateBaseRate(policyDetails?.Revenue ?? 0);

        var upcomingLimitFactor = await CalculateLimitFactor(coverage?.OccuranceLimit ?? 0m, coverage?.AggregateLimit ?? 0m, coverage?.Retention ?? 0m);

        var limitsAdjustedPremium = premium / upcomingPriorBaseRate * priorBaseRate / upcomingLimitFactor * priorLimitFactor;

        var rateChange = (limitsAdjustedPremium / policyDetails?.EO_GWP - 1) * 100;

        return rateChange ?? 0m;
    }
    private async Task<decimal?> CalculateLimitFactor(decimal occrLimit, decimal aggrLimit, decimal retention)
    {
        //F157 in Calculations excel sheet
        var eoRetention = retention;

        //F158 in Calculations excel sheet
        var occAndEoRetention = (occrLimit) + eoRetention;

        var limitRetentionFactors = await _limitRetentionFactorRepository.GetAll(_raterOptions.Version);

        var forRetention = limitRetentionFactors.Where(x => x.LimitRetentionOption <= eoRetention).OrderByDescending(x => x.LimitRetentionOption).FirstOrDefault();

        //F160 in Calculations excel sheet
        var eoRetentionLowValue = forRetention?.LimitRetentionOption;

        var forOccurance = limitRetentionFactors.Where(x => x.LimitRetentionOption > eoRetentionLowValue).OrderBy(x => x.LimitRetentionOption).FirstOrDefault();

        //F161 in Calculations excel sheet
        var eoRetentionHighValue = forOccurance?.LimitRetentionOption;

        var forRetentionCoef = limitRetentionFactors.Where(x => x.LimitRetentionOption <= occAndEoRetention).OrderByDescending(x => x.LimitRetentionOption).FirstOrDefault();

        //F162 in Calculations excel sheet
        var occLimitLowValue = forRetentionCoef?.LimitRetentionOption;

        var forOccuranceCoef = limitRetentionFactors.Where(x => x.LimitRetentionOption > occLimitLowValue).OrderBy(x => x.LimitRetentionOption).FirstOrDefault();

        //F163 in Calculations excel sheet
        var occLimitHighValue = forOccuranceCoef?.LimitRetentionOption;

        //F165 in Calculations excel sheet
        var retentionLowCoef = forRetention?.EoMedium;
        //F166 in Calculations excel sheet
        var retentionHighCoef = forOccurance?.EoMedium;
        //F167 in Calculations excel sheet
        var occLimitLowCoef = forRetentionCoef?.EoMedium;
        //F168 in Calculations excel sheet
        var occLimitHighCoef = forOccuranceCoef?.EoMedium;

        //F170 in Calculations excel sheet
        var retentionWeightedCoeff = ((eoRetention - eoRetentionLowValue) / (eoRetentionHighValue - eoRetentionLowValue) * retentionHighCoef) + (1 - (eoRetention - eoRetentionLowValue) / (eoRetentionHighValue - eoRetentionLowValue)) * retentionLowCoef;

        //F171 in Calculations excel sheet
        var occRetentionWeightedCoeff = ((occAndEoRetention - occLimitLowValue) / (occLimitHighValue - occLimitLowValue) * occLimitHighCoef) + (1 - (occAndEoRetention - occLimitLowValue) / (occLimitHighValue - occLimitLowValue)) * occLimitLowCoef;

        //F172 in Calculations excel sheet
        var limitRetentionFactor = occRetentionWeightedCoeff - retentionWeightedCoeff;

        //F176 in Calculations excel sheet
        var retainedSplitLimitValue = 1 + ((aggrLimit - occrLimit) / occrLimit);

        var retainedValueFactorMatrix = await _retainedValueFactorMatrixRepository.GetAll(_raterOptions.Version);

        var lowRetainedFactorMatrixValue = retainedValueFactorMatrix.Where(x => x.RetainedValue <= retainedSplitLimitValue).OrderByDescending(x => x.RetainedValue).FirstOrDefault();

        //F177 in Calculations excel sheet
        var occAggLowSplitLimitValue = lowRetainedFactorMatrixValue?.RetainedValue;

        //F180 in Calculations excel sheet
        var occAggLowSplitLimitCoef = lowRetainedFactorMatrixValue?.FactorEO;

        var highRetainedValue = retainedValueFactorMatrix.Where(x => x.RetainedValue > retainedSplitLimitValue).OrderBy(x => x.RetainedValue).FirstOrDefault();

        //F178 in Calculations excel sheet
        var occAggHighSplitLimitValue = highRetainedValue?.RetainedValue;

        //F181 in Calculations excel sheet
        var occAggHighSplitLimitCoef = highRetainedValue?.FactorEO;

        //F183 in Calculations excel sheet
        var splitLimitFactor = ((retainedSplitLimitValue - occAggLowSplitLimitValue) / (occAggHighSplitLimitValue - occAggLowSplitLimitValue) * occAggHighSplitLimitCoef) + (1 - (retainedSplitLimitValue - occAggLowSplitLimitValue) / (occAggHighSplitLimitValue - occAggLowSplitLimitValue)) * occAggLowSplitLimitCoef;

        //F187 in Calculations excel sheet
        var retainedSharedLimit = 100;

        var retainedValueFactor = await _retainedValueFactorRepository.GetAll(_raterOptions.Version);

        var lowRetainedValueFactor = retainedValueFactor.Where(x => x.RetainedValuePercent <= retainedSharedLimit).OrderByDescending(x => x.RetainedValuePercent).FirstOrDefault();

        //F188 in Calculations excel sheet
        var sharedLimitLowValue = lowRetainedValueFactor?.RetainedValuePercent / 100;

        //F191 in Calculations excel sheet
        var sharedLimitLowCoef = lowRetainedValueFactor?.Factor;

        var highRetainedValueFactor = retainedValueFactor.Where(x => x.RetainedValuePercent > retainedSharedLimit).OrderBy(x => x.RetainedValuePercent).FirstOrDefault();

        //F189 in Calculations excel sheet
        var sharedLimitHighValue = highRetainedValueFactor?.RetainedValuePercent / 100;

        //F192 in Calculations excel sheet
        var sharedLimitHighCoef = highRetainedValueFactor?.Factor;

        //F194 in Calculations excel sheet
        var sharedLimit = (retainedSharedLimit - sharedLimitLowValue) / (sharedLimitHighValue - sharedLimitLowValue) * (sharedLimitHighCoef - sharedLimitLowCoef) + sharedLimitLowCoef;

        //F196 in Calculations excel sheet
        var xsLimitFactor = 1;

        return limitRetentionFactor * splitLimitFactor * sharedLimit * xsLimitFactor;
    }
}
