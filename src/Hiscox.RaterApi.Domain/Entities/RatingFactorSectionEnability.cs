// Copyright (c) Hiscox Insurance. All rights reserved.

namespace Hiscox.RaterApi.Domain.Entities;

public class RatingFactorSectionEnability
{
    public required string Version { get; set; }
    public int Id { get; set; }
    public int Section { get; set; }
    public int Size { get; set; }
    public bool Enabled { get; set; }
}
