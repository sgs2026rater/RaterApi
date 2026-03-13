// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApiWrapper.Domain.Enums;

namespace Hiscox.RaterApiWrapper.Domain.Entities;

public class AdditionalRiskProfile
{
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
    public WorkUndertakenFrequency WorkUndertakenFrequencyQuestion { get; set; }
    public bool? LimitationOfLiabilityQuestion { get; set; }
    // Alternative exposure base specific to Trustees specialty
    public decimal AlternativeExposureBase_Trustees { get; set; }
    #region Accountants
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
}
