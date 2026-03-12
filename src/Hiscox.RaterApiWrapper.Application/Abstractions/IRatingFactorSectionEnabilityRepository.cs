// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApiWrapper.Domain.Entities;

namespace Hiscox.RaterApiWrapper.Application.Abstractions;

public interface IRatingFactorSectionEnabilityRepository
{
    Task<IEnumerable<RatingFactorSectionEnability>> GetAll(string version);
    Task<RatingFactorSectionEnability?> CheckEnabled(string version, int section, int size);
}