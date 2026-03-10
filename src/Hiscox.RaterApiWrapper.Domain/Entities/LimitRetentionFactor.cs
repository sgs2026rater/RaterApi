// Copyright (c) Hiscox Insurance. All rights reserved.

using System;
using System.Collections.Generic;
using System.Text;

namespace Hiscox.RaterApiWrapper.Domain.Entities;

public class LimitRetentionFactor
{
    public required string Version { get; set; }
    public int Id { get; set; }
    public long? LimitRetentionOption { get; set; }
    public decimal? EoLow { get; set; }
    public decimal? EoMedium { get; set; }
    public decimal? EoHigh { get; set; }
    public decimal? FactorGlPremisesOperations { get; set; }
    public decimal? FactorGlProductsOperations { get; set; }
    public decimal? FactorCyber { get; set; }
}
