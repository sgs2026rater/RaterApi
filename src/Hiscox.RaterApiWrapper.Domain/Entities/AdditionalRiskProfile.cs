// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApiWrapper.Domain.Enums;
using System.ComponentModel.DataAnnotations;

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
}
