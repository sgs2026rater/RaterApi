// Copyright (c) Hiscox Insurance. All rights reserved.


// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApiWrapper.Domain.Entities;

namespace Hiscox.RaterApiWrapper.Application.Abstractions;

public interface IRetainedValueFactorRepository
{
    Task<IEnumerable<RetainedValueFactor>> GetAll(string version);
}