// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApiWrapper.Application.Abstractions;
using Hiscox.RaterApiWrapper.Domain.Caching;
using Hiscox.RaterApiWrapper.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace Hiscox.RaterApiWrapper.Infrastructure.Data.Repositories;

public class LimitRetentionFactorRepository : RepositoryBase, ILimitRetentionFactorRepository
{
    public LimitRetentionFactorRepository(ApplicationDbContext context, IMemoryCache memoryCache, ILogger<LimitRetentionFactorRepository> logger)
        : base(context, memoryCache, logger)
    {
    }

    public async Task<IEnumerable<LimitRetentionFactor>> GetAll(string version)
    {
        return await _context.LimitRetentionFactors!
            .Where(_ => _.Version == version)
            .OrderBy(_ => _.Id)
            .ToListAsync();
    }

}
