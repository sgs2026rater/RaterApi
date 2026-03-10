// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApiWrapper.Application.Abstractions;
using Hiscox.RaterApiWrapper.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace Hiscox.RaterApiWrapper.Infrastructure.Data.Repositories;

public class OptCovTable1Repository : RepositoryBase, IOptCovTable1Repository
{
    public OptCovTable1Repository(ApplicationDbContext context, IMemoryCache memoryCache, ILogger<OptCovTable1Repository> logger) : base(context, memoryCache, logger)
    {
    }

    public async Task<IEnumerable<OptCovTable1>> GetAll(string version)
    {
        return await _context.OptCovTables!
           .Where(_ => _.Version == version)
           .OrderBy(_ => _.Id)
           .ToListAsync();
    }
}
