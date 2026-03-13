// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApi.Application.Abstractions;
using Hiscox.RaterApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace Hiscox.RaterApi.Infrastructure.Data.Repositories;

public class RetainedValueFactorMatrixRepository : RepositoryBase, IRetainedValueFactorMatrixRepository
{
    public RetainedValueFactorMatrixRepository(ApplicationDbContext context, IMemoryCache memoryCache, ILogger<RetainedValueFactorMatrixRepository> logger)
        : base(context, memoryCache, logger)
    {
    }

    public async Task<IEnumerable<RetainedValueFactorMatrix>> GetAll(string version)
    {
        return await _context.RetainedValueFactorMatrixs!
            .Where(_ => _.Version == version)
            .OrderBy(_ => _.Id)
            .ToListAsync();
    }

}
