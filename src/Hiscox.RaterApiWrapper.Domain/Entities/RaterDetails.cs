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
    public List<DisplayedDefaultPeril>? DisplayedDefaultPerils { get; set; }
    public List<DataValidation>? DataValidations { get; set; }
    public List<OptionalCoveragesTable1>? OptionalCoveragesTable1Records { get; set; }
    public List<OptionalCoveragesTable2>? OptionalCoveragesTable2Records { get; set; }

    #endregion Coverage(Tab6)

    #region Accountants specific fields
    public decimal BookKeepingServicesRevenuePercentage { get; set; }
    public decimal PersonalTaxAndEnrolledAgentServicesRevenuePercentage { get; set; }
    public decimal PayrollServicesRevenuePercentage { get; set; }
    public decimal BusinessTaxServicesRevenuePercentage { get; set; }
    public decimal AuditingServicesRevenuePercentage { get; set; }
    public decimal EstateTaxReturnsRevenuePercentage { get; set; }
    public decimal ForensicAccountingRevenuePercentage { get; set; }
    public decimal BusinessValuationsOrForecastsRevenuePercentage { get; set; }
    public decimal LitigationSupportRevenuePercentage { get; set; }
    public decimal AuditingServices_HighNetWorthClients_10M_assetsRevenuePercentage { get; set; }
    public decimal AuditingServices_FinancialInstitutionsOrPensionsRevenuePercentage { get; set; }
    public decimal FinancialPlanningServicesRevenuePercentage { get; set; }
    public decimal TrusteeServices_PersonalTrusteeRevenuePercentage { get; set; }
    public decimal TrusteeServices_BankruptcyTrusteeRevenuePercentage { get; set; }
    public decimal ReviewAndCompilationsRevenuePercentage { get; set; }
    public decimal OtherRevenuePercentage { get; set; }
    public bool HighNetWorthClientOrBusinessOver100M { get; set; }
    #endregion Accountants specific fields

    // Warnings or informational messages generated during rating calculation
    public List<string>? Warnings { get; set; }

    #region RatingFactor

    public decimal? Premium { get; set; }

    #endregion RatingFactor

    #region Summary


    public decimal? RenewalPremium { get; set; }
    public decimal? LimitFactor { get; set; }
    public decimal? BaseRateForChosenExposure { get; set; }
    public decimal? RevenueChange { get; set; }
    public decimal? PremiumChange { get; set; }
    public decimal? RateChange { get; set; }

    #endregion Summary

    #region Industry(Financial Services)
    public bool AccountantsCheck { get; set; }
    public bool ClaimsAdjustersCheck { get; set; }
    public bool InterimManagementCheck { get; set; }
    public decimal AlternativeExposureBaseRevenue { get; set; }
    #endregion Industry(Financial Services)
}