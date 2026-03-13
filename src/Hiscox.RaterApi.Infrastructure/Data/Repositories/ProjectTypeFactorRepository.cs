// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApi.Application.Abstractions;
using Hiscox.RaterApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace Hiscox.RaterApi.Infrastructure.Data.Repositories;

public class ProjectTypeFactorRepository : RepositoryBase, IProjectTypeFactorRepository
{
    public ProjectTypeFactorRepository(ApplicationDbContext context, IMemoryCache memoryCache, ILogger<ProjectTypeFactorRepository> logger)
        : base(context, memoryCache, logger)
    {
    }

    public async Task<IEnumerable<ProjectTypeFactor>> GetAll(string version)
    {
        return await _context.ProjectTypeFactors!
            .Where(_ => _.Version == version)
            .OrderBy(_ => _.Id)
            .ToListAsync();
    }

}
