// Copyright (c) Hiscox Insurance. All rights reserved.

namespace Hiscox.RaterApiWrapper.Domain.Entities;

public class IndustryClassification
{
    public int? SectorId { get; set; }
    public required string SectorName { get; set; }

    public int? SubSectorId { get; set; }
    public required string SubSectorName { get; set; }

    public int? SpecialtyId { get; set; }
    public required string SpecialtyName { get; set; }
    
    public decimal PercentageExposure { get; set; }
}
