// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApiWrapper.Application.Abstractions;
using Hiscox.RaterApiWrapper.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace Hiscox.RaterApiWrapper.Infrastructure.Data.Repositories;

public class OptionalCoveragesTable2Repository : RepositoryBase, IOptionalCoveragesTable2Repository
{
    public OptionalCoveragesTable2Repository(ApplicationDbContext context, IMemoryCache memoryCache, ILogger<OptionalCoveragesTable2Repository> logger) : base(context, memoryCache, logger)
    {
    }

    public async Task<IEnumerable<OptionalCoveragesTable2>> GetAll(string version)
    {
        return await _context.OptionalCoveragesTable2s!
           .Where(_ => _.Version == version)
           .OrderBy(_ => _.Id)
           .ToListAsync();
    }

    public async Task<OptionalCoveragesTable2?> GetByCoverage(string version, string coverage)
    {
        return await _context.OptionalCoveragesTable2s!
           .Where(_ => _.Version == version && _.Coverage == coverage)
           .OrderBy(_ => _.Id)
           .FirstOrDefaultAsync();
    }
}