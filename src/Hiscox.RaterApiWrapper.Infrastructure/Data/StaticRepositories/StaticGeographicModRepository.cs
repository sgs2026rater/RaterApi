// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApiWrapper.Application.Abstractions;
using Hiscox.RaterApiWrapper.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System.Text;

namespace Hiscox.RaterApiWrapper.Infrastructure.Data.Repositories;

public class StaticGeographicModRepository : RepositoryBase, IGeographicModRepository
{
    private readonly IStaticDatasets _staticDatasets;

    public StaticGeographicModRepository(ApplicationDbContext context, IMemoryCache memoryCache, IStaticDatasets staticDatasets, ILogger<GeographicModRepository> logger) : base(context, memoryCache, logger)
    {
        _staticDatasets = staticDatasets;
    }

    public async Task<string> GetMetroArea(string version, string zipCode)
    {
        return _staticDatasets.GeographiModDictionary![zipCode].MsaName;
    }

    public async Task<decimal> GetAE(string version, string zipCode)
    {
        return _staticDatasets.GeographiModDictionary![zipCode].AE;
    }
}
