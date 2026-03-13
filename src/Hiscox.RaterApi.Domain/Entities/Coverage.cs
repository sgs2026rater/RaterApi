// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApi.Domain.Enums;

namespace Hiscox.RaterApi.Domain.Entities;

public class Coverage
{
    public CoverageType CoverageType { get; set; }
    public decimal ExpiringPremium { get; set; }
    public decimal OccuranceLimit { get; set; }
    public decimal AggregateLimit { get; set; }
    public decimal Retention { get; set; }
}
