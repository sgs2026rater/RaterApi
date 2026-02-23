// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApiWrapper.Domain.Enums;

namespace Hiscox.RaterApiWrapper.Domain.Entities;

public record RaterInputs
{
    public string? Product { get; set; }
    public ProductName? PolicyNumber { get; set; }
    public BusinessType? BusinessType { get; set; }
    public List<Coverage>? Coverages { get; set; }
    public List<IndustryClassification>? IndustryClassifications { get; set; }
    public AdditionalRiskProfile? AdditionalRiskProfile { get; set; }
    public List<Claim>? ClaimsHistory { get; set; }
    public OptionalEnhancements? OptionalEnhancements { get; set; }
}
