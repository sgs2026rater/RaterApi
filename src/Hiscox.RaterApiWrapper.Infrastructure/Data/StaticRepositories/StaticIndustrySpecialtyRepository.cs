// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApiWrapper.Application.Abstractions;
using Hiscox.RaterApiWrapper.Domain.Caching;
using Hiscox.RaterApiWrapper.Domain.Entities;
using Hiscox.RaterApiWrapper.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace Hiscox.RaterApiWrapper.Infrastructure.Data.StaticRepositories;

public class StaticIndustrySpecialtyRepository : RepositoryBase, IIndustrySpecialtyRepository
{
    private readonly IStaticDatasets _staticDatasets;

    public StaticIndustrySpecialtyRepository(ApplicationDbContext context, IMemoryCache memoryCache, IStaticDatasets staticDatasets, ILogger<StaticIndustrySectorRepository> logger)
        : base(context, memoryCache, logger)
    {
        _staticDatasets = staticDatasets;
    }

    public async Task<IEnumerable<IndustrySpecialty>> GetAll(string version)
    {
        return _staticDatasets.IndustrySpecialtyList!.Where(x => x.Version == version);
    }

    public async Task<IEnumerable<IndustrySpecialty>> GetAllFromCacheOrSource(string version)
    {
        return await GetAll(version);
    }

}
