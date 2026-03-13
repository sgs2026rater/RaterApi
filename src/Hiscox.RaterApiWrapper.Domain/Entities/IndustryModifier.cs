// Copyright (c) Hiscox Insurance. All rights reserved.

using System;
using System.Collections.Generic;
using System.Text;

namespace Hiscox.RaterApiWrapper.Domain.Entities;

public class IndustryModifier
{
    public required string Version { get; set; }
    public int Id { get; set; }
    public string Specialty { get; set; }= string.Empty;
    public decimal NAICSModifier { get; set; }
}
