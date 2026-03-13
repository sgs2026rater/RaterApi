// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApi.Application.Abstractions;
using Hiscox.RaterApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace Hiscox.RaterApi.Infrastructure.Data.Repositories;

public class OptionalCoverageFactorsRepository : RepositoryBase, IOptionalCoverageFactorsRepository
{
    public OptionalCoverageFactorsRepository(ApplicationDbContext context, IMemoryCache memoryCache, ILogger<OptionalCoverageFactorsRepository> logger)
        : base(context, memoryCache, logger)
    {
    }

    public async Task<IEnumerable<OptionalCoverageFactor>> GetAll(string version)
    {
        return await _context.OptionalCoverageFactors!
            .Where(_ => _.Version == version)
            .OrderBy(_ => _.Id)
            .ToListAsync();
    }

    public async Task<IEnumerable<OptionalCoverageFactor>> GetByEnhancementName(string version, string enhancementName)
    {
        return await _context.OptionalCoverageFactors!
            .Where(_ => _.Version == version && _.Type == enhancementName)
            .OrderBy(_ => _.Id)
            .ToListAsync();
    }

}
