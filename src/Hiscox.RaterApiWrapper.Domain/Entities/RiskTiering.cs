// Copyright (c) Hiscox Insurance. All rights reserved.

using System;
using System.Collections.Generic;
using System.Text;

namespace Hiscox.RaterApiWrapper.Domain.Entities;

public class RiskTiering
{
    public required string Version { get; set; }
    public int Id { get; set; }
    public int IndustrySectorId { get; set; }
    public int SectionId { get; set; }
    public int QuestionId { get; set; }
    public decimal Factor { get; set; }
}
