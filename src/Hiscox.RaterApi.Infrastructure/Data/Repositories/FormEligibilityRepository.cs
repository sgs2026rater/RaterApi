// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApi.Application.Abstractions;
using Hiscox.RaterApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace Hiscox.RaterApi.Infrastructure.Data.Repositories;

public class FormEligibilityRepository : RepositoryBase, IFormEligibilityRepository
{
    public FormEligibilityRepository(ApplicationDbContext context, IMemoryCache memoryCache, ILogger<FormEligibilityRepository> logger)
        : base(context, memoryCache, logger)
    {
    }

    public async Task<IEnumerable<FormEligibility>> GetAll(string version)
    {
        return await _context.FormEligibilities!
            .Where(_ => _.Version == version)
            .OrderBy(_ => _.IndustrySpecialtyId)
                .ThenBy(_ => _.FormId)
            .ToListAsync();
    }

    public async Task<IEnumerable<FormEligibility>> GetForIndustrySpeciality(string version, int industrySpecialtyId)
    {
        return await _context.FormEligibilities!
            .Where(_ => _.Version == version && _.IndustrySpecialtyId == industrySpecialtyId)
            .OrderBy(_ => _.FormId)
            .ToListAsync();
    }

}
