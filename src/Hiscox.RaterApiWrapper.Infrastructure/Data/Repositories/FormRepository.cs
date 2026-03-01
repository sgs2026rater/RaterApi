// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApiWrapper.Application.Abstractions;
using Hiscox.RaterApiWrapper.Domain.Caching;
using Hiscox.RaterApiWrapper.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace Hiscox.RaterApiWrapper.Infrastructure.Data.Repositories;

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
