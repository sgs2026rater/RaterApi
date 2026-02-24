// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApiWrapper.Domain.Enums;

namespace Hiscox.RaterApiWrapper.Domain.Entities;

public record RaterInputs
{
    public ProductName? Product { get; set; }
    public string? PolicyNumber { get; set; }
    public decimal Revenue { get; set; }
    public bool AlternativeExposureBase { get; set; }
    public bool EO { get; set; }
    public bool GL { get; set; }
    public bool Cyber { get; set; }
    public bool Crime { get; set; }
    public BusinessType? BusinessType { get; set; }
    public List<Coverage>? Coverages { get; set; }
    public List<IndustryClassification>? IndustryClassifications { get; set; }
    public AdditionalRiskProfile? AdditionalRiskProfile { get; set; }
    public List<Claim>? ClaimsHistory { get; set; }
    public OptionalEnhancements? OptionalEnhancements { get; set; }
}
