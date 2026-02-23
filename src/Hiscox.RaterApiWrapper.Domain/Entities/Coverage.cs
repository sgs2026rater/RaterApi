// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApiWrapper.Domain.Enums;

namespace Hiscox.RaterApiWrapper.Domain.Entities;

public class Coverage
{
    public CoverageType CoverageType { get; set; }
    public decimal OccuranceLimit { get; set; }
    public decimal AggregateLimit { get; set; }
    public decimal Retention { get; set; }
}
