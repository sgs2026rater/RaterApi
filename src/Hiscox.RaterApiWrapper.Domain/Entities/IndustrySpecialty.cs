// Copyright (c) Hiscox Insurance. All rights reserved.

namespace Hiscox.RaterApiWrapper.Domain.Entities;

public record IndustrySpecialty
{
    public required string Version { get; set; }
    public int Id { get; set; }
    public int IndustrySubSectorId { get; set; }
    public required string Name { get; set; }
}
