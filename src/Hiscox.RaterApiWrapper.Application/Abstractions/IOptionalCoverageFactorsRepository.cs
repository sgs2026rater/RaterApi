// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApiWrapper.Domain.Entities;

namespace Hiscox.RaterApiWrapper.Application.Abstractions;

public interface IOptionalCoverageFactorsRepository
{
    Task<IEnumerable<OptionalCoverageFactor>> GetAll(string version);
}