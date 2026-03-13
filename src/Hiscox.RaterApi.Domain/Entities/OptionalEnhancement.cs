// Copyright (c) Hiscox Insurance. All rights reserved.

namespace Hiscox.RaterApi.Domain.Entities;

public class OptionalEnhancement
{
    //public OptionalEnhancementName? OptionalEnhancementName { get; set; }
    public string? OptionalEnhancementName { get; set; }

    public string? OptionalEnhancementValue { get; set; }
    public string? Differential { get; set; }
    public string? ApplicableTo { get; set; }
    public string? Version { get; set; }
}
