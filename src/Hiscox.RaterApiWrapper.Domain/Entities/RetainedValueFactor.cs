// Copyright (c) Hiscox Insurance. All rights reserved.

using System;
using System.Collections.Generic;
using System.Text;

namespace Hiscox.RaterApiWrapper.Domain.Entities;

public class RetainedValueFactor
{
    public required string Version { get; set; }
    public int Id { get; set; }
    public decimal RetainedValuePercent { get; set; }
    public decimal Factor { get; set; }
}
