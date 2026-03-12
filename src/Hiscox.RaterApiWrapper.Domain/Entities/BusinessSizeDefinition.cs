// Copyright (c) Hiscox Insurance. All rights reserved.

using System;
using System.Collections.Generic;
using System.Text;

namespace Hiscox.RaterApiWrapper.Domain.Entities;

public class BusinessSizeDefinition
{
    public required string Version { get; set; }
    public int Id { get; set; }
    public int CoverageType { get; set; }
    public int Size { get; set; }
    public decimal Revenue { get; set; }
}
