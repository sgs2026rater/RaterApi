// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApi.Application.Abstractions;
using Hiscox.RaterApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace Hiscox.RaterApi.Infrastructure.Data.Repositories;

public class MagicPolicyRepository : RepositoryBase, IMagicPolicyRepository
{
    public MagicPolicyRepository(ApplicationDbContext context, IMemoryCache memoryCache, ILogger<MagicPolicyRepository> logger) : base(context, memoryCache, logger)
    {
    }

    public async Task<PolicyDetails?> GetByPolicyNumber(string version, string PolicyNumber)
    {
        return await _context.MagicPolicy!
            .Where(_ => _.Version == version && _.PolicyNo == PolicyNumber)
            .OrderBy(_ => _.Id)
            .FirstOrDefaultAsync();
    }
}