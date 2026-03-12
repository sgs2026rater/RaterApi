// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApiWrapper.Application.Abstractions;
using Hiscox.RaterApiWrapper.Domain.Caching;
using Hiscox.RaterApiWrapper.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace Hiscox.RaterApiWrapper.Infrastructure.Data.Repositories;

public class RatingFactorSectionEnabilityRepository : RepositoryBase, IRatingFactorSectionEnabilityRepository
{
    public RatingFactorSectionEnabilityRepository(ApplicationDbContext context, IMemoryCache memoryCache, ILogger<RatingFactorSectionEnabilityRepository> logger)
        : base(context, memoryCache, logger)
    {
    }

    public async Task<IEnumerable<RatingFactorSectionEnability>> GetAll(string version)
    {
        return await _context.RatingFactorSectionEnabilities!
            .Where(_ => _.Version == version)
            .OrderBy(_ => _.Id)
            .ToListAsync();
    }

    public async Task<RatingFactorSectionEnability?> CheckEnabled(string version, int section, int size)
    {
        return await _context.RatingFactorSectionEnabilities!
            .Where(_ => _.Version == version && _.Section == section && _.Size == size).FirstOrDefaultAsync();
    }

}
