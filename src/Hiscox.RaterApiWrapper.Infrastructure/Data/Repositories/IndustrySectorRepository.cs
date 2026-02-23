// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApiWrapper.Application.Abstractions;
using Hiscox.RaterApiWrapper.Domain.Caching;
using Hiscox.RaterApiWrapper.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace Hiscox.RaterApiWrapper.Infrastructure.Data.Repositories;

public class IndustrySectorRepository : RepositoryBase, IIndustrySectorRepository
{
    public IndustrySectorRepository(ApplicationDbContext context, IMemoryCache memoryCache, ILogger<IndustrySectorRepository> logger)
        : base(context, memoryCache, logger)
    {
    }

    public async Task<IEnumerable<IndustrySector>> GetAll(string version)
    {
        return await _context.IndustrySectors!
            .Where(_ => _.Version == version)
            .OrderBy(_ => _.Id)
            .ToListAsync();
    }

    public async Task<IEnumerable<IndustrySector>> GetAllFromCacheOrSource(string version)
    {
        return await base.GetAllFromCacheOrSource<IndustrySector>(version, CacheKeys.IndustrySectorCacheKey, "Industry Sectors", GetAll);
    }

}
