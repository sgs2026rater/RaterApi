// Copyright (c) Hiscox Insurance. All rights reserved.

using System;
using System.Collections.Generic;
using System.Text;

namespace Hiscox.RaterApiWrapper.Domain.Entities;

public class RevenueBaseRate
{
    public int? Revenue { get; set; }
    public decimal BaseRateEO { get; set; }
    public decimal GLPremisesOperations1 { get; set; }
    public decimal GLPremisesOperations2 { get; set; }
    public decimal BaseRateCyber { get; set; }
    public decimal BaseRateTechEO { get; set; }
    public decimal BaseRateAHC { get; set; }
    public decimal BaseRateHomeHealthcare { get; set; }
    public decimal BaseRateSpas { get; set; }
}
