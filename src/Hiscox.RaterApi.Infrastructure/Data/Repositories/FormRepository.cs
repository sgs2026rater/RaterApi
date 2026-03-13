// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApi.Application.Abstractions;
using Hiscox.RaterApi.Domain.Caching;
using Hiscox.RaterApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace Hiscox.RaterApi.Infrastructure.Data.Repositories;

public class FormRepository : RepositoryBase, IFormRepository
{
    public FormRepository(ApplicationDbContext context, IMemoryCache memoryCache, ILogger<FormRepository> logger)
        : base(context, memoryCache, logger)
    {
    }

    public async Task<IEnumerable<Form>> GetAll(string version)
    {
        return await _context.Forms!
            .Where(_ => _.Version == version)
            .OrderBy(_ => _.Id)
            .ToListAsync();
    }

    public async Task<IEnumerable<Form>> GetAllFromCacheOrSource(string version)
    {
        return await base.GetAllFromCacheOrSource<Form>(version, CacheKeys.FormCacheKey, "Forms", GetAll);
    }

}
