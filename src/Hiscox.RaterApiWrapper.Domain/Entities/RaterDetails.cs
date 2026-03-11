// Copyright (c) Hiscox Insurance. All rights reserved.

namespace Hiscox.RaterApiWrapper.Domain.Entities;

public record RaterDetails
{
    public RaterInputs? RaterInputs { get; set; }
    public PolicyDetails? Profile { get; set; }
    public decimal Revenue {  get; set; }
    public decimal RevenueAdjusted { get; set; }
    public List<IndustryClassification>? IndustryClassifications { get; set; }
    public IndustryClassification? PrimaryIndustryClassification { get; set; }
    public List<IndustryClassification>? AdditionalIndustryClassifications { get; set; }
    public string? ChosenForm {  get; set; }
    public string? FormType { get; set; }
    public RatingFactor? RatingFactorStep { get; set; }
    public Coverage? PrimaryCoverage { get; set; }

    #region Additional UW(Tab4)

    public bool TangibleGoodsOrProductOwnerFlag { get; set; }//This is to control if Q3 is visible.
    public bool ProjectTier4Ans { get; set; } = false;
    public bool ProjectTier5Ans { get; set; } = false; 
    public bool UITrigDesignprof3MRevFlag{ get; set; }//refer ui_control B195 value 
    public bool LimitationOfLiabilityQuestionFlag { get; set; }
    public bool UITrigAnEFlag { get; set; }

    #endregion Additional UW(Tab4)
    
    #region Coverage(Tab6)
    public string SharedOrSeparatedEAndO { get; set; } = "N/A";
    public string? IncludedCoverageEnhancements { get; set; }
    public List<OptionalEnhancement>? OptionalEnhancements { get; set; }
    public List<OptCovTable1>? OptCovTable1Records {  get; set; }
    public Dictionary<string,string>? OptionalCoverageNameToDefaultAmountMap {  get; set; }
    public Dictionary<string,string>? OptionalCoverageNameToDataValidationMap { get; set;  }
    public List<OptionalCoveragesTable1>? OptionalCoveragesTable1Records { get; set; }
    public Dictionary<string,string>? OptionalCoverageToDifferentialMap {  get; set; }

    #endregion Coverage(Tab6)

    #region RatingFactor

    public decimal? Premium {  get; set; }

    #endregion RatingFactor

    #region Summary


    public decimal? RenewalPremium { get; set; }
    public decimal? LimitFactor { get; set; }
    public decimal? BaseRateForChosenExposure { get; set; }
    public decimal? RevenueChange { get; set; }
    public decimal? PremiumChange { get; set; }
    public decimal? RateChange { get; set; }

    #endregion Summary
}