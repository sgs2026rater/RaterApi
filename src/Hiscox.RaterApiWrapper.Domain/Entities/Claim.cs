// Copyright (c) Hiscox Insurance. All rights reserved.

namespace Hiscox.RaterApiWrapper.Domain.Entities;

public class Claim
{
    public DateTime DateOfClaim { get; set; }
    public required string PartiesToClaim { get; set; }
    public required string StatusOfClaim { get; set; }
}
