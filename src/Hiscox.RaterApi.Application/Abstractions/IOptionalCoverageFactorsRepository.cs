// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApi.Domain.Entities;

namespace Hiscox.RaterApi.Application.Abstractions;

public interface IOptionalCoverageFactorsRepository
{
    Task<IEnumerable<OptionalCoverageFactor>> GetAll(string version);
    Task<IEnumerable<OptionalCoverageFactor>> GetByEnhancementName(string version, string enhancementName);
}