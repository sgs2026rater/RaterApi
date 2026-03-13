// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApiWrapper.Domain.Enums;

namespace Hiscox.RaterApiWrapper.Domain.Entities;

public class OptionalEnhancement
{
    //public OptionalEnhancementName? OptionalEnhancementName { get; set; }
    public string? OptionalEnhancementName { get; set; }

    public string? OptionalEnhancementValue { get; set; }
    public string? Differential { get; set; }
    public string? ApplicableTo { get; set; }
    public string? Version { get; set; }
}
