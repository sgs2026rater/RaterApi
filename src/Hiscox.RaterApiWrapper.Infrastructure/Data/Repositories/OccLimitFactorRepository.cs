// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApiWrapper.Application.Abstractions;
using Hiscox.RaterApiWrapper.Domain.Caching;
using Hiscox.RaterApiWrapper.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace Hiscox.RaterApiWrapper.Infrastructure.Data.Repositories;

public class OccLimitFactorRepository : RepositoryBase, IOccLimitFactorRepository
{
    public OccLimitFactorRepository(ApplicationDbContext context, IMemoryCache memoryCache, ILogger<OccLimitFactorRepository> logger)
        : base(context, memoryCache, logger)
    {
    }

    public async Task<IEnumerable<OccLimitFactor>> GetAll(string version)
    {
        return await _context.OccLimitFactors!
            .Where(_ => _.Version == version)
            .OrderBy(_ => _.Id)
            .ToListAsync();
    }

}
