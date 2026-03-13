// Copyright (c) Hiscox Insurance. All rights reserved.

namespace Hiscox.RaterApi.Domain.Entities;

public class OptionalCoreCoverage
{
    public string CoverageName { get; set; } = string.Empty;
    public string SelectionInRater { get; set; } = string.Empty;
    public decimal? ValueToUse { get; set; }
    public decimal PercentOfOccLimit { get; set; }
    public decimal LowLookupValue { get; set; }
    public decimal HighLookupValue { get; set; }
    public decimal LowCoefficient { get; set; }
    public decimal HighCoefficient { get; set; }
    public decimal ValueOfInsurance { get; set; }
}
