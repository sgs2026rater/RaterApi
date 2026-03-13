// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApi.Application.Abstractions;
using Hiscox.RaterApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace Hiscox.RaterApi.Infrastructure.Data.Repositories;

public class BusinessSizeDefinitionRepository : RepositoryBase, IBusinessSizeDefinitionRepository
{
    public BusinessSizeDefinitionRepository(ApplicationDbContext context, IMemoryCache memoryCache, ILogger<BusinessSizeDefinitionRepository> logger)
        : base(context, memoryCache, logger)
    {
    }

    public async Task<IEnumerable<BusinessSizeDefinition>> GetAll(string version)
    {
        return await _context.BusinessSizeDefinitions!
            .Where(_ => _.Version == version)
            .OrderBy(_ => _.Id)
            .ToListAsync();
    }

    public async Task<BusinessSizeDefinition?> GetByRevenue(string version, decimal revenue)
    {
        return await _context.BusinessSizeDefinitions!
            .Where(_ => _.Version == version && _.Revenue <= revenue)
            .OrderByDescending(_ => _.Revenue).FirstOrDefaultAsync();
    }

}
