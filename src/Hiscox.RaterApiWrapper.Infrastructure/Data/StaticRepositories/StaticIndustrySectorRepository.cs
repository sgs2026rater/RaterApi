// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApiWrapper.Application.Abstractions;
using Hiscox.RaterApiWrapper.Domain.Entities;
using Hiscox.RaterApiWrapper.Infrastructure.Data.Repositories;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace Hiscox.RaterApiWrapper.Infrastructure.Data.StaticRepositories;

public class StaticIndustrySectorRepository : RepositoryBase, IIndustrySectorRepository
{
    private readonly IStaticDatasets _staticDatasets;

    public StaticIndustrySectorRepository(ApplicationDbContext context, IMemoryCache memoryCache, IStaticDatasets staticDatasets, ILogger<StaticIndustrySectorRepository> logger)
        : base(context, memoryCache, logger)
    {
        _staticDatasets = staticDatasets;
    }

    public async Task<IEnumerable<IndustrySector>> GetAll(string version)
    {
        return _staticDatasets.IndustrySectorList!.Where(x => x.Version == version);
    }

    public async Task<IEnumerable<IndustrySector>> GetAllFromCacheOrSource(string version)
    {
        return await GetAll(version);
    }

}
