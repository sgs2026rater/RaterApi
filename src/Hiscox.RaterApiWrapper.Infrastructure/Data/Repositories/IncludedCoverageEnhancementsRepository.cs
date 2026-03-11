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

    public async Task<string?> GetCoverageEnhancementsByForm(string version, string form)
    {
        return await _context.IncludedCoverageEnhancements!
         .Where(x => x.Version == version && x.Form == form)
         .OrderBy(x => x.Id)
         .Select(x => x.CoverageEnhancements)
         .FirstOrDefaultAsync();
    }
}
