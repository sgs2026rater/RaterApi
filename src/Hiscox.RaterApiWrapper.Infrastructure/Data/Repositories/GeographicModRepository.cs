// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApiWrapper.Application.Abstractions;
using Hiscox.RaterApiWrapper.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hiscox.RaterApiWrapper.Infrastructure.Data.Repositories;

public class GeographicModRepository : RepositoryBase, IGeographicModRepository
{
    public GeographicModRepository(ApplicationDbContext context, IMemoryCache memoryCache, ILogger<GeographicModRepository> logger) : base(context, memoryCache, logger)
    {
    }

    public async Task<string> GetMetroArea(string version, string zipCode)
    {
        return await _context.GeographicMods!
            .Where(_ => _.Version == version && _.Zip == zipCode)
            .OrderBy(_ => _.Id)
            .Select(_ => _.MsaName)
            .FirstAsync();
    }
}
