// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApi.Application.Abstractions;
using Hiscox.RaterApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace Hiscox.RaterApi.Infrastructure.Data.Repositories;

public class OptionalAdditionalCoverageFactorsRepository : RepositoryBase, IOptionalAdditionalCoverageFactorsRepository
{
    public OptionalAdditionalCoverageFactorsRepository(ApplicationDbContext context, IMemoryCache memoryCache, ILogger<OptionalAdditionalCoverageFactorsRepository> logger)
        : base(context, memoryCache, logger)
    {
    }

    public async Task<IEnumerable<OptionalAdditionalCoverageFactor>> GetAll(string version)
    {
        return await _context.OptionalAdditionalCoverageFactors!
            .Where(_ => _.Version == version)
            .OrderBy(_ => _.Id)
            .ToListAsync();
    }

    public async Task<OptionalAdditionalCoverageFactor?> GetCoverage(string version, string coverage)
    {
        return await _context.OptionalAdditionalCoverageFactors!
            .Where(_ => _.Version == version && _.Coverage == coverage)
            .FirstOrDefaultAsync();
    }

}
