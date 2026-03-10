// Copyright (c) Hiscox Insurance. All rights reserved.

using System;
using System.Collections.Generic;
using System.Text;

namespace Hiscox.RaterApiWrapper.Domain.Entities;

public class RetainedValueFactorMatrix
{
    public required string Version { get; set; }
    public int Id { get; set; }
    public decimal RetainedValue { get; set; }
    public decimal FactorEO { get; set; }
    public decimal FactorGL { get; set; }
    public decimal FactorCyber { get; set; }
}
