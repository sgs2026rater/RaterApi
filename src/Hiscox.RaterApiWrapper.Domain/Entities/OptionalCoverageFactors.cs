// Copyright (c) Hiscox Insurance. All rights reserved.

using System;
using System.Collections.Generic;
using System.Text;

namespace Hiscox.RaterApiWrapper.Domain.Entities;

public class OptionalCoverageFactor
{
    public required string Version { get; set; }
    public int Id { get; set; }
    public decimal PercentOfOccLimit { get; set; }
    public string Type { get; set; } = string.Empty;
    public decimal Factor { get; set; }
}
