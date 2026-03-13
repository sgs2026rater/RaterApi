// Copyright (c) Hiscox Insurance. All rights reserved.

namespace Hiscox.RaterApi.Domain.Entities;

public class OptionalCoveragesTable2    // Excel location - Optional_coverages!C276:R335
{
    public required string Version { get; set; }
    public int Id { get; set; }
    public required string Coverage { get; set; }   // Excel Column C
    public required string Differential { get; set; }   // Excel Column R
}