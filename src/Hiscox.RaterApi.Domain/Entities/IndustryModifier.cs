// Copyright (c) Hiscox Insurance. All rights reserved.

namespace Hiscox.RaterApi.Domain.Entities;

public class IndustryModifier
{
    public required string Version { get; set; }
    public int Id { get; set; }
    public string Specialty { get; set; } = string.Empty;
    public decimal NAICSModifier { get; set; }
    public decimal EOMinimumPremium { get; set; }
}
