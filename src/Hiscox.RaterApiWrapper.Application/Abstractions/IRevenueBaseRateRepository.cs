// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApiWrapper.Domain.Entities;

namespace Hiscox.RaterApiWrapper.Application.Abstractions;

public interface IRevenueBaseRateRepository
{
    Task<IEnumerable<RevenueBaseRate>> GetAll(string version);
}