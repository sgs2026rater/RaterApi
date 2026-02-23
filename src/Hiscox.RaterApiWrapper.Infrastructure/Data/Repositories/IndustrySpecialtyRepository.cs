// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApiWrapper.Application.Abstractions;
using Hiscox.RaterApiWrapper.Domain.Caching;
using Hiscox.RaterApiWrapper.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace Hiscox.RaterApiWrapper.Infrastructure.Data.Repositories;

public class IndustrySpecialtyRepository : RepositoryBase, IIndustrySpecialtyRepository
{
    public IndustrySpecialtyRepository(ApplicationDbContext context, IMemoryCache memoryCache, ILogger<IndustrySpecialtyRepository> logger)
        : base(context, memoryCache, logger)
    {
    }

    public async Task<IEnumerable<IndustrySpecialty>> GetAll(string version)
    {
        return await _context.IndustrySpecialties!
            .Where(_ => _.Version == version)
            .OrderBy(_ => _.Id)
            .ToListAsync();
    }

    public async Task<IEnumerable<IndustrySpecialty>> GetAllFromCacheOrSource(string version)
    {
        return await base.GetAllFromCacheOrSource<IndustrySpecialty>(version, CacheKeys.IndustrySectorCacheKey, "Industry Specialty", GetAll);
    }

}
