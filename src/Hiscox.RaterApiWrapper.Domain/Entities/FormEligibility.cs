// Copyright (c) Hiscox Insurance. All rights reserved.

namespace Hiscox.RaterApiWrapper.Domain.Entities;

public record FormEligibility
{
    public required string Version { get; set; }
    public int IndustrySpecialtyId { get; set; }
    public int FormId { get; set; }
}
