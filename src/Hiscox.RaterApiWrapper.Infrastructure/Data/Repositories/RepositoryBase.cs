// Copyright (c) Hiscox Insurance. All rights reserved.

using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace Hiscox.RaterApiWrapper.Infrastructure.Data.Repositories;

public abstract class RepositoryBase
{
    protected readonly ApplicationDbContext _context;
    protected readonly IMemoryCache _memoryCache;
    protected readonly ILogger _logger;

    protected RepositoryBase(ApplicationDbContext context, IMemoryCache memoryCache, ILogger logger)
    {
        _context = context;
        _memoryCache = memoryCache;
        _logger = logger;
    }

    public async Task<IEnumerable<T>> GetAllFromCacheOrSource<T>(string version, string cacheKey, string dataEntityName, Func<string, Task<IEnumerable<T>>> func)
    {
        if (_memoryCache.TryGetValue(cacheKey, out IEnumerable<T>? data))
        {
            _logger.LogInformation("{0} retrieved from cache.", dataEntityName);
            return data!;
        }

        _logger.LogInformation("{0} not found in cache. Retrieving from source.", dataEntityName);
        var dataFromSource = await func(version);

        _memoryCache.Set(cacheKey, dataFromSource, TimeSpan.FromMinutes(60));
        _logger.LogInformation("{0} saved to cache.", dataEntityName);
        return dataFromSource;
    }
}
