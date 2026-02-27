// Copyright (c) Hiscox Insurance. All rights reserved.


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

    //[Required]
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
    
    public OptionalEnhancementsRq? OptionalEnhancements { get; set; }
}

public class AdditionalRiskProfileRq
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

}

public class OptionalEnhancementsRq
{
    public decimal? DamagesToPremises { get; set; }
    public decimal? MedicalPayments { get; set; }
    public decimal? PersonalAndAdvertisingInjury { get; set; }
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