// Copyright (c) Hiscox Insurance. All rights reserved.

using System;
using System.Collections.Generic;
using System.Text;

namespace Hiscox.RaterApiWrapper.Domain.Entities;

public class ProjectTypeFactor
{
    public string ProjectType { get; set; } = string.Empty;
    public decimal Factor { get; set; }
}
