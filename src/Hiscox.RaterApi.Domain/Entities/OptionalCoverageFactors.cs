// Copyright (c) Hiscox Insurance. All rights reserved.

namespace Hiscox.RaterApi.Domain.Entities;

public class OptionalCoverageFactor
{
    public required string Version { get; set; }
    public int Id { get; set; }
    public decimal PercentOfOccLimit { get; set; }
    public string Type { get; set; } = string.Empty;
    public decimal Factor { get; set; }
}
