// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApiWrapper.Application.Abstractions;
using Hiscox.RaterApiWrapper.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace Hiscox.RaterApiWrapper.Infrastructure.Data.Repositories;

public class StaticPolicyRepository : RepositoryBase, IPolicyRepository
{
    private readonly IStaticDatasets _staticDatasets;

    public StaticPolicyRepository(ApplicationDbContext context, IMemoryCache memoryCache, IStaticDatasets staticDatasets, ILogger<PolicyRepository> logger) : base(context, memoryCache, logger)
    {
        _staticDatasets = staticDatasets;
    }

    public async Task<PolicyDetails?> GetByPolicyNumber(string version, string PolicyNumber)
    {
        return _staticDatasets.PolicyDetailsList!
            .Where(_ => _.Version == version && _.PolicyNo == PolicyNumber)
            .OrderBy(_ => _.Id)
            .FirstOrDefault();
    }
}