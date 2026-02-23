// Copyright (c) Hiscox Insurance. All rights reserved.

namespace Hiscox.RaterApiWrapper.Domain.Entities;

public record IndustrySubSector
{
    public required string Version { get; set; }
    public int Id { get; set; }
    public int IndustrySectorId { get; set; }
    public required string Name { get; set; } = string.Empty;
}
