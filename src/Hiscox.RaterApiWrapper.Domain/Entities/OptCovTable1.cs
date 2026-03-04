// Copyright (c) Hiscox Insurance. All rights reserved.

using System;
using System.Collections.Generic;
using System.Text;

namespace Hiscox.RaterApiWrapper.Domain.Entities;

public class OptCovTable1
{
    public string? OptionalCoverage {  get; set; }//Column B in OptCov Sheet
    public string? ApplicableToCoverageOrGTC { get; set; }//Column E in OptCov Sheet
    public string? ApplicableToFormOrEndorsment { get; set; }//Column Q in OptCov Sheet
    public string? ENumber {  get; set; }//Column R in OptCov Sheet

}
