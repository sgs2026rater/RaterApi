// Copyright (c) Hiscox Insurance. All rights reserved.

using System;
using System.Collections.Generic;
using System.Text;

namespace Hiscox.RaterApiWrapper.Domain.Entities;

public class OptionalCoveragesTable1
{
    //Table from C7 to M65 in Optional_Coverages sheet.

    public required string Version { get; set; }
    public int Id { get; set; }
    public string? OptionalAdditionalCoverage { get; set; }
    public decimal ValueOfInsurance {  get; set; }
    public decimal Premium { get; set; }
}
