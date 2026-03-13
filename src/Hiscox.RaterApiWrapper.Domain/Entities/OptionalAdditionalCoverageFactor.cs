// Copyright (c) Hiscox Insurance. All rights reserved.

using System;
using System.Collections.Generic;
using System.Text;

namespace Hiscox.RaterApiWrapper.Domain.Entities;

public class OptionalAdditionalCoverageFactor
{
    public required string Version { get; set; }
    public int Id { get; set; }
    public string Coverage { get; set; } = string.Empty;
    public decimal YesFactor { get; set; }
    public decimal MinimalFactor { get; set; }
    public decimal MaterialFactor { get; set; }
}
