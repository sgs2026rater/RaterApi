// Copyright (c) Hiscox Insurance. All rights reserved.

using System;
using System.Collections.Generic;
using System.Text;

namespace Hiscox.RaterApiWrapper.Domain.Entities;

public class OccLimitFactor
{
    public decimal PercentOfOccLimit { get; set; }
    public decimal ClassActionSublimit { get; set; }
    public decimal CrisisManagement { get; set; }
    public decimal MediaActivities { get; set; }
    public decimal TechnologyCoverageExtension { get; set; }    
}
