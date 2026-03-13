// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApi.Application.Abstractions;
using Hiscox.RaterApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace Hiscox.RaterApi.Infrastructure.Data.Repositories;

public class IndustryModifierRepository : RepositoryBase, IIndustryModifierRepository
{
    public IndustryModifierRepository(ApplicationDbContext context, IMemoryCache memoryCache, ILogger<IndustryModifierRepository> logger)
        : base(context, memoryCache, logger)
    {
    }

    public async Task<IEnumerable<IndustryModifier>> GetAll(string version)
    {
        return await _context.IndustryModifiers!
            .Where(_ => _.Version == version)
            .OrderBy(_ => _.Id)
            .ToListAsync();
    }

    public async Task<decimal> GetNAICSModifierBySpecialty(string version, string specialty)
    {
        return await _context.IndustryModifiers!
            .Where(_ => _.Version == version && _.Specialty == specialty)
            .Select(_ => _.NAICSModifier)
            .FirstOrDefaultAsync();
    }

    public async Task<decimal> GetEOMimimumPremiumBySpecialty(string version, string specialty)
    {
        return await _context.IndustryModifiers!
            .Where(_ => _.Version == version && _.Specialty == specialty)
            .Select(_ => _.EOMinimumPremium)
            .FirstOrDefaultAsync();
    }

}
