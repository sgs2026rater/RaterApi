// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApiWrapper.Application.Abstractions;
using Hiscox.RaterApiWrapper.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace Hiscox.RaterApiWrapper.Infrastructure.Data.Repositories;

public class PolicyRepository : RepositoryBase, IPolicyRepository
{
    public PolicyRepository(ApplicationDbContext context, IMemoryCache memoryCache, ILogger<PolicyRepository> logger) : base(context, memoryCache, logger)
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