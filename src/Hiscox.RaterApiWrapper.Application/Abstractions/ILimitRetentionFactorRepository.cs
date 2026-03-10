// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApiWrapper.Domain.Entities;

namespace Hiscox.RaterApiWrapper.Application.Abstractions;

public interface ILimitRetentionFactorRepository
{
    Task<IEnumerable<LimitRetentionFactor>> GetAll(string version);
}