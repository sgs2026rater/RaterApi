// Copyright (c) Hiscox Insurance. All rights reserved.

namespace Hiscox.RaterApiWrapper.Domain.Entities;

public class DisplayedDefaultPeril   // Excel location - OptCov!B67:H93
{
    public required string Version { get; set; }
    public int Id { get; set; }
    public required string DefaultPeril { get; set; }  // Excel Column B
    public required bool IsSwitchedOnByDefault { get; set; }    // Excel Column C
    public required string DefaultValueWhenSwitchedOn { get; set; } // Excel Column D
    public required string ApplicableTo { get; set; }   // Excel Column F
}