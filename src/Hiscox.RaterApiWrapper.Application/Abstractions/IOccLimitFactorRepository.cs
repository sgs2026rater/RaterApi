// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApiWrapper.Domain.Entities;

namespace Hiscox.RaterApiWrapper.Application.Abstractions;

public interface IOccLimitFactorRepository
{
    Task<IEnumerable<OccLimitFactor>> GetAll(string version);
}