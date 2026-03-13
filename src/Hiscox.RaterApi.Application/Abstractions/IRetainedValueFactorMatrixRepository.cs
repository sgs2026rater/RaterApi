// Copyright (c) Hiscox Insurance. All rights reserved.


// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApi.Domain.Entities;

namespace Hiscox.RaterApi.Application.Abstractions;

public interface IRetainedValueFactorMatrixRepository
{
    Task<IEnumerable<RetainedValueFactorMatrix>> GetAll(string version);
}