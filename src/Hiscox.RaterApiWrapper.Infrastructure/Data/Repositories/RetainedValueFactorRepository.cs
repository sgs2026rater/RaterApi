// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApiWrapper.Application.Abstractions;
using Hiscox.RaterApiWrapper.Domain.Caching;
using Hiscox.RaterApiWrapper.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace Hiscox.RaterApiWrapper.Infrastructure.Data.Repositories;

public class RetainedValueFactorRepository : RepositoryBase, IRetainedValueFactorRepository
{
    public RetainedValueFactorRepository(ApplicationDbContext context, IMemoryCache memoryCache, ILogger<RetainedValueFactorRepository> logger)
        : base(context, memoryCache, logger)
    {
    }

    public async Task<IEnumerable<RetainedValueFactor>> GetAll(string version)
    {
        return await _context.RetainedValueFactors!
            .Where(_ => _.Version == version)
            .OrderBy(_ => _.Id)
            .ToListAsync();
    }

}
