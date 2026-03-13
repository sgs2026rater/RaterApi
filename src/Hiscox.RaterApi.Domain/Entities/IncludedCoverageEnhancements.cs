// Copyright (c) Hiscox Insurance. All rights reserved.

namespace Hiscox.RaterApi.Domain.Entities;

public class IncludedCoverageEnhancements
{
    public required string Version { get; set; }
    public int Id { get; set; }
    public required string Form { get; set; }
    public required string LineOfBusiness { get; set; }
    public required string ShortenedLineOfBusiness { get; set; }
    public required string ClaimsMode { get; set; }
    public required string CoverageEnhancements { get; set; }

}
