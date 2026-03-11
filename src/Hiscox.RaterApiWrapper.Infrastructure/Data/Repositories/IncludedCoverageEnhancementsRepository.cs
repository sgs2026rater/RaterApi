// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApiWrapper.Application.Abstractions;
using Hiscox.RaterApiWrapper.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace Hiscox.RaterApiWrapper.Infrastructure.Data.Repositories;

public class IncludedCoverageEnhancementsRepository : RepositoryBase, IIncludedCoverageEnhancementsRepository
{
    public IncludedCoverageEnhancementsRepository(ApplicationDbContext context, IMemoryCache memoryCache, ILogger<IncludedCoverageEnhancementsRepository> logger)
       : base(context, memoryCache, logger)
    {
    }

    public async Task<IEnumerable<IncludedCoverageEnhancements>> GetByForm(string version, string form)
    {
        return await _context.IncludedCoverageEnhancements!
            .Where(_ => _.Version == version && _.Form == form)
            .OrderBy(_ => _.Id)
            .ToListAsync();
    }
}
