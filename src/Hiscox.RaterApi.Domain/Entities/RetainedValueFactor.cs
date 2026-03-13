// Copyright (c) Hiscox Insurance. All rights reserved.

namespace Hiscox.RaterApi.Domain.Entities;

public class RetainedValueFactor
{
    public required string Version { get; set; }
    public int Id { get; set; }
    public int RetainedValuePercent { get; set; }
    public decimal Factor { get; set; }
}
