// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApiWrapper.Application.Abstractions;
using Hiscox.RaterApiWrapper.Domain.Entities;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Hiscox.RaterApiWrapper.Infrastructure.Data.Repositories;

public class MagicPolicyRepository : RepositoryBase, IMagicPolicyRepository
{
    public MagicPolicyRepository(ApplicationDbContext context, IMemoryCache memoryCache, ILogger logger) : base(context, memoryCache, logger)
    {
    }

    public async Task<PolicyDetails> GetByPolicyNumber(string version, string PolicyNumber)
    {
        return await _context.MagicPolicy!
            .Where(_ => _.Version == version && _.PolicyNo == PolicyNumber)
            .OrderBy(_ => _.Id)
            .FirstAsync();
    }
}