// Copyright (c) Hiscox Insurance. All rights reserved.

using System;
using System.Collections.Generic;
using System.Text;

namespace Hiscox.RaterApiWrapper.Domain.Entities;

public class IndustryFormMaster
{
    public int Id { get; set; }
    public string Version { get; set; } = string.Empty;
    public string FormName { get; set; } = string.Empty;
}
