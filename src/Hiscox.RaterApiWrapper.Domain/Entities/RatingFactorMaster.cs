// Copyright (c) Hiscox Insurance. All rights reserved.

using System;
using System.Collections.Generic;
using System.Text;

namespace Hiscox.RaterApiWrapper.Domain.Entities;

public class RatingFactorMaster
{
    public required string Version { get; set; }
    public int Id { get; set; }
    public int SectionId { get; set; }
    public int QuestionId { get; set; }
    public bool Answer { get; set; } = true;
    public decimal Factor { get; set; }
    public decimal Low { get; set; }
    public decimal High { get; set; }
    public string DegreeOfConcern { get; set; } = string.Empty;
}
