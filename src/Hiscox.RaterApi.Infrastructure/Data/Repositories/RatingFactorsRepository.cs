// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApi.Application.Abstractions;
using Hiscox.RaterApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace Hiscox.RaterApi.Infrastructure.Data.Repositories;

public class RatingFactorsRepository : RepositoryBase, IRatingFactorsRepository
{
    public RatingFactorsRepository(ApplicationDbContext context, IMemoryCache memoryCache,
            ILogger<RatingFactorsRepository> logger) : base(context, memoryCache, logger)
    {
    }
    public async Task<List<RatingFactorMaster>> GetRatingFactorBySection(string version, short sectionId)
    {
        return await _context.RatingFactor!
            .Where(_ => _.Version == version && _.SectionId == sectionId).ToListAsync();
    }
    public async Task<RatingFactorMaster?> GetRatingFactorByQuestion(string version, short sectionId, short questionId)
    {
        return await _context.RatingFactor!
            .Where(_ => _.Version == version && _.SectionId == sectionId && _.QuestionId == questionId)
            .FirstOrDefaultAsync();
    }
}
