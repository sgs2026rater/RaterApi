// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApi.Domain.Entities;

namespace Hiscox.RaterApi.Application.Abstractions;

public interface IOptionalCoverageTable1Repository
{
    Task<IEnumerable<OptionalCoveragesTable1>> GetAll(string version);
}
