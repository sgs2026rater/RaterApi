// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApi.Domain.Entities;

namespace Hiscox.RaterApi.Application.Abstractions;

public interface IOptionalAdditionalCoverageFactorsRepository
{
    Task<IEnumerable<OptionalAdditionalCoverageFactor>> GetAll(string version);
    Task<OptionalAdditionalCoverageFactor?> GetCoverage(string version, string coverage);
}