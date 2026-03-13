// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApi.Domain.Entities;

namespace Hiscox.RaterApi.Application.Abstractions;

public interface IRevenueBaseRateRepository
{
    Task<IEnumerable<RevenueBaseRate>> GetAll(string version);
}