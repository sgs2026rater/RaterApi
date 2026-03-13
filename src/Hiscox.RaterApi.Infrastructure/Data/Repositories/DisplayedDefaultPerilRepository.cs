// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApi.Application.Abstractions;
using Hiscox.RaterApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace Hiscox.RaterApi.Infrastructure.Data.Repositories;

public class DisplayedDefaultPerilRepository : RepositoryBase, IDisplayedDefaultPerilRepository
{
    public DisplayedDefaultPerilRepository(ApplicationDbContext context, IMemoryCache memoryCache, ILogger<DisplayedDefaultPerilRepository> logger) : base(context, memoryCache, logger)
    {
    }

    public async Task<IEnumerable<DisplayedDefaultPeril>> GetAll(string version)
    {
        return await _context.DisplayedDefaultPerils!
           .Where(_ => _.Version == version)
           .OrderBy(_ => _.Id)
           .ToListAsync();
    }

    public async Task<DisplayedDefaultPeril?> GetByPeril(string version, string peril)
    {
        return await _context.DisplayedDefaultPerils!
           .Where(_ => _.Version == version && _.DefaultPeril == peril)
           .OrderBy(_ => _.Id)
           .FirstOrDefaultAsync();
    }
}