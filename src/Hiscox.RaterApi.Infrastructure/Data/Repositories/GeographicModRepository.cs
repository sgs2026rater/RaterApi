// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApi.Application.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace Hiscox.RaterApi.Infrastructure.Data.Repositories;

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

    public async Task<decimal> GetAE(string version, string zipCode)
    {
        return await _context.GeographicMods!
            .Where(_ => _.Version == version && _.Zip == zipCode)
            .OrderBy(_ => _.Id)
            .Select(_ => _.AE)
            .FirstAsync();
    }
}
