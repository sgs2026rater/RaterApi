// Copyright (c) Hiscox Insurance. All rights reserved.

using System;
using System.Collections.Generic;
using System.Text;

namespace Hiscox.RaterApiWrapper.Domain.Entities;

public class RatingFactorSectionDetails
{
    public int SectionId { get; set; }
    public string DegreeOfConcern { get; set; } = string.Empty;
    public decimal Factor { get; set; }
    public string Range { get; set; } = string.Empty;
    public decimal Suggested { get; set; }
    public string FurtherClaimInformation { get; set; } = string.Empty;
}
