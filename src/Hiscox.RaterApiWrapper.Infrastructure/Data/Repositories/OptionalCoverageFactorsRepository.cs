// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApiWrapper.Application.Abstractions;
using Hiscox.RaterApiWrapper.Domain.Caching;
using Hiscox.RaterApiWrapper.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace Hiscox.RaterApiWrapper.Infrastructure.Data.Repositories;

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

}
