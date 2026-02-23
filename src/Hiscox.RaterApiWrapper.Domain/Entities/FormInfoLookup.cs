// Copyright (c) Hiscox Insurance. All rights reserved.

using System;
using System.Collections.Generic;
using System.Text;

namespace Hiscox.RaterApiWrapper.Domain.Entities;

public class FormInfoLookup
{
    public int Id { get; set; }

    public required string FormName { get; set; }

    public required string LineOfBusiness { get; set; }

    public required string LineOfBusinessShort { get; set; }
    public required string DefaultClaimBasis { get; set; }
    public required string CoverageEnhancements { get; set; }
}
