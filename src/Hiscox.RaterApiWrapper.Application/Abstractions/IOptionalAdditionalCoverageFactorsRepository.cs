// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApiWrapper.Domain.Entities;

namespace Hiscox.RaterApiWrapper.Application.Abstractions;

public interface IOptionalAdditionalCoverageFactorsRepository
{
    Task<IEnumerable<OptionalAdditionalCoverageFactor>> GetAll(string version);
    Task<OptionalAdditionalCoverageFactor?> GetCoverage(string version, string coverage);
}