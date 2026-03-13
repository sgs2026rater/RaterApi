// Copyright (c) Hiscox Insurance. All rights reserved.


using Hiscox.RaterApiWrapper.Domain.Entities;
using Hiscox.RaterApiWrapper.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Hiscox.RaterApiWrapper.Presentation.Api.Contracts;

public class RaterRequest
{
    [Required]
    [EnumDataType(typeof(ProductName))]
    public required string Product { get; set; }

    [Required]
    public string? PolicyNumber { get; set; }

    [Required]
    public decimal? Revenue { get; set; }

    [Required]
    [EnumDataType(typeof(BusinessType))]
    public required string BusinessType { get; set; }

    [Required]
    public List<CoverageRq>? Coverages { get; set; }

    [Required]
    public required List<IndustryClassificationRq> IndustryClassifications { get; set; }

    [Required]
    public AdditionalRiskProfileRq? AdditionalRiskProfile { get; set; }

    public List<ClaimRq>? ClaimsHistory { get; set; }

    public List<OptionalEnhancementRq>? OptionalEnhancements { get; set; }
    public RatingFactor? RatingFactorStep { get; set; }
}

public class AdditionalRiskProfileRq
{
    #region Design Professional
    public bool EnvironmentalRemediation { get; set; }
    public bool UndergroundUtilityLocators { get; set; }
    public bool Nuclear { get; set; }
    public bool Offshore { get; set; }
    public bool Superfund { get; set; }
    public bool UndergroundStorage { get; set; }
    public bool ZipLines { get; set; }
    public bool AmusementParks { get; set; }
    public bool Prototypes { get; set; }
    public bool TangibleGoodsOrProduct { get; set; }
    public bool? TangibleGoodsOrProductOwner { get; set; }
    //[EnumDataType(typeof(ProjectType))]
    //public List<ProjectType>? ProjectTypes { get; set; }
    public List<string>? ProjectTypes { get; set; }
    public bool HighValueHomes { get; set; }
    public bool SeniorHousingAssistedLiving { get; set; }
    public bool LowIncomeHousing { get; set; }
    public bool DataCenters { get; set; }
    public bool MajorStadiumArena { get; set; }
    public bool StandAlongParking { get; set; }
    public bool TractHomes { get; set; }
    public bool OfficeHighRiseSkyscrapers { get; set; }
    public bool? ExperienceMoreThan5YearsQuestion { get; set; }
    [EnumDataType(typeof(WorkUndertakenFrequency))]
    public WorkUndertakenFrequency WorkUndertakenFrequencyQuestion { get; set; }
    public bool? LimitationOfLiabilityQuestion { get; set; }
    #endregion Design Professional

    #region Financial Services
    #region Accountants
    //Below flags should be enabled in request when  _raterDetails.AccountantsCheck is true;
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
    #endregion Accountants
    #region Claims Adjuster
    public string? CatastrophicServiceEventPercentage { get; set; }//should be enabled in request when  _raterDetails.ClaimsAdjustersCheck is true;(The values can be None/1-25%/26-50%/>50%)
    #endregion Claims Adjuster
    #region Interim Management Services
    //should be enabled in request when _raterDetails.InterimManagementCheck = true
    //Question 1 in Interim Management Services Specialty
    public bool? InterimManagement { get; set; }//If the value is Unknown/null, then there is a warning displays "Prior to binding subjectivity required."
                                                //If the value is True, then warning message as "Decline".
    //Question 2 in Interim Management Services Specialty
    public bool? WorksWithClientsAtInterimCompany { get; set; }//If the value is Unknown/null, then there is a warning displays "Prior to binding subjectivity required."
    //Question 3 in Interim Management Services Specialty
    public bool? HasFiveYearsExperienceForIndicatedServices { get; set; }
    [EnumDataType(typeof(WorkUndertakenFrequency))]
    public WorkUndertakenFrequency ContractOrAgreementWorkFrequency { get; set; }//If the value is Unknown, then there is a warning displays "Prior to binding subjectivity required."
    public bool? IsDAndOInsuranceRequired { get; set; }
    public bool? IsLiabilityCappedAt3TimesFees { get; set; }
    #endregion Interim Management Services
    #region Trustees
    public decimal AlternativeExposureBase_Trustees { get; set; }
    public bool IsTrusteeBeneficiaryAlsoClient { get; set; }
    public bool AssetDecreased15PercentOrMore { get; set; }
    public bool IsTrustRevocable { get; set; }

    #endregion Trustees
    #endregion Financial Services

}

public class OptionalEnhancementRq
{
    //[JsonConverter(typeof(JsonStringEnumConverter))]
    //public OptionalEnhancementName? OptionalEnhancementName { get; set; }
    public string? OptionalEnhancementName { get; set; }

    public string? OptionalEnhancementValue { get; set; }
}

public class CoverageRq
{
    [EnumDataType(typeof(CoverageType))]
    [Required]
    public required string CoverageType { get; set; }
    public decimal OccuranceLimit { get; set; }
    public decimal AggregateLimit { get; set; }
    public decimal Retention { get; set; }
}

public class IndustryClassificationRq
{
    [Required]
    [JsonPropertyName("Sector")]
    public required string SectorName { get; set; }

    [Required]
    [JsonPropertyName("SubSector")]
    public required string SubSectorName { get; set; }

    [Required]
    [JsonPropertyName("Specialty")]
    public required string SpecialtyName { get; set; }

    [Required]
    public decimal PercentageExposure { get; set; }
}

public class ClaimRq
{
    [Required]
    public DateTime DateOfClaim { get; set; }

    [Required]
    public required string PartiesToClaim { get; set; }

    [Required]
    public required string StatusOfClaim { get; set; }
}