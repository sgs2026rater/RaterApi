// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApiWrapper.Application.Abstractions;
using Hiscox.RaterApiWrapper.Domain.Entities;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hiscox.RaterApiWrapper.Infrastructure.Data.Repositories;

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
