// Copyright (c) Hiscox Insurance. All rights reserved.

using System;
using System.Collections.Generic;
using System.Text;

namespace Hiscox.RaterApiWrapper.Domain.Entities;

public class IncludedCoverageEnhancements
{
    public required string Version { get; set; }
    public int Id { get; set; }
    public required string Form {  get; set; }
    public required string LineOfBusiness { get; set; }    
    public required string ShortenedLineOfBusiness { get; set; }
    public required string ClaimsMode {  get; set; }
    public required string CoverageEnhancements { get; set; }

}
