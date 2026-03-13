// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApi.Application.Abstractions;
using Hiscox.RaterApi.Domain.Caching;
using Hiscox.RaterApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace Hiscox.RaterApi.Infrastructure.Data.Repositories;

public class IndustrySubSectorRepository : RepositoryBase, IIndustrySubSectorRepository
{
    public IndustrySubSectorRepository(ApplicationDbContext context, IMemoryCache memoryCache, ILogger<IndustrySubSectorRepository> logger)
        : base(context, memoryCache, logger)
    {
    }

    public async Task<IEnumerable<IndustrySubSector>> GetAll(string version)
    {
        return await _context.IndustrySubSectors!
            .Where(_ => _.Version == version)
            .OrderBy(_ => _.Id)
            .ToListAsync();
    }

    public async Task<IEnumerable<IndustrySubSector>> GetAllFromCacheOrSource(string version)
    {
        return await base.GetAllFromCacheOrSource<IndustrySubSector>(version, CacheKeys.IndustrySectorCacheKey, "Industry SubSectors", GetAll);
    }

}

