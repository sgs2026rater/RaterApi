// Copyright (c) Hiscox Insurance. All rights reserved.

namespace Hiscox.RaterApi.Domain.Entities;

public class BusinessSizeDefinition
{
    public required string Version { get; set; }
    public int Id { get; set; }
    public int CoverageType { get; set; }
    public int Size { get; set; }
    public decimal Revenue { get; set; }
}
