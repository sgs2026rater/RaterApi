// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApi.Application.Abstractions;
using Hiscox.RaterApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace Hiscox.RaterApi.Infrastructure.Data.Repositories;

public class RevenueBaseRateRepository : RepositoryBase, IRevenueBaseRateRepository
{
    public RevenueBaseRateRepository(ApplicationDbContext context, IMemoryCache memoryCache, ILogger<RevenueBaseRateRepository> logger)
        : base(context, memoryCache, logger)
    {
    }

    public async Task<IEnumerable<RevenueBaseRate>> GetAll(string version)
    {
        return await _context.RevenueBaseRates!
            .Where(_ => _.Version == version)
            .OrderBy(_ => _.Id)
            .ToListAsync();
    }

}
