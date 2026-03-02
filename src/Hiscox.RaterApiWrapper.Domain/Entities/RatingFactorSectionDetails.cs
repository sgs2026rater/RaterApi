// Copyright (c) Hiscox Insurance. All rights reserved.

using System;
using System.Collections.Generic;
using System.Text;

namespace Hiscox.RaterApiWrapper.Domain.Entities;

public class RatingFactorSectionDetails
{
    public int SectionId { get; set; }
    public bool Answer { get; set; } = true;
    public decimal Factor { get; set; }
    public decimal Low { get; set; }
    public decimal High { get; set; }
    public string DegreeOfConcern { get; set; } = string.Empty;
}
