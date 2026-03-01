// Copyright (c) Hiscox Insurance. All rights reserved.

namespace Hiscox.RaterApiWrapper.Domain.Entities;

public record Form
{
    public required string Version { get; set; }
    public int Id { get; set; }
    public required string Name { get; set; }
}
