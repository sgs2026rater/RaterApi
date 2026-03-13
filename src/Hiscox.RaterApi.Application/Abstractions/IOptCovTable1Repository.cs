// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApi.Domain.Entities;

namespace Hiscox.RaterApi.Application.Abstractions;

public interface IOptCovTable1Repository
{
    Task<IEnumerable<OptCovTable1>> GetAll(string version);
}
