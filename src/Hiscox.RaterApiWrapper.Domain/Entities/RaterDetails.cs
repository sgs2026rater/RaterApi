// Copyright (c) Hiscox Insurance. All rights reserved.

namespace Hiscox.RaterApiWrapper.Domain.Entities;

public record RaterDetails
{
    public PolicyDetails? Profile { get; set; }
    public List<IndustryClassification>? IndustryClassifications { get; set; }
}
