// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApiWrapper.Application.Abstractions;
using Hiscox.RaterApiWrapper.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace Hiscox.RaterApiWrapper.Infrastructure.Data.Repositories;

public class DataValidationRepository : RepositoryBase, IDataValidationRepository
{
    public DataValidationRepository(ApplicationDbContext context, IMemoryCache memoryCache, ILogger<DataValidationRepository> logger) : base(context, memoryCache, logger)
    {
    }

    public async Task<IEnumerable<DataValidation>> GetAll(string version)
    {
        return await _context.DataValidations!
           .Where(_ => _.Version == version)
           .OrderBy(_ => _.Id)
           .ToListAsync();
    }

    public async Task<DataValidation?> GetByPeril(string version, string peril)
    {
        return await _context.DataValidations!
           .Where(_ => _.Version == version && _.Peril == peril)
           .OrderBy(_ => _.Id)
           .FirstOrDefaultAsync();
    }
}