// Copyright (c) Hiscox Insurance. All rights reserved.

using System;
using System.Collections.Generic;
using System.Text;

namespace Hiscox.RaterApiWrapper.Domain.Entities;

public class IndustryForm
{
    public int Id { get; set; }
    public string Version { get; set; } = string.Empty;
    public int SpecialtyId { get; set; }
    public int DefaultFormId { get; set; }
}
