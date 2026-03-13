// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApi.Application.Abstractions;
using Hiscox.RaterApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace Hiscox.RaterApi.Infrastructure.Data.Repositories;

public class OptionalCoverageTable1Repository : RepositoryBase, IOptionalCoverageTable1Repository
{
    public OptionalCoverageTable1Repository(ApplicationDbContext context, IMemoryCache memoryCache, ILogger<OptionalCoverageTable1Repository> logger) : base(context, memoryCache, logger)
    {
    }

    public async Task<IEnumerable<OptionalCoveragesTable1>> GetAll(string version)
    {
        return await _context.OptionalCoveragesTables!
           .Where(_ => _.Version == version)
           .OrderBy(_ => _.Id)
           .ToListAsync();
    }

}
