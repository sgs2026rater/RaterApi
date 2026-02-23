// Copyright (c) Hiscox Insurance. All rights reserved.

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
    public List<string>? ProjectTypes { get; set; }
}
