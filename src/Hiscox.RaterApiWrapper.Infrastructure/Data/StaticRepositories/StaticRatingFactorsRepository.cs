// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApiWrapper.Application.Abstractions;
using Hiscox.RaterApiWrapper.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace Hiscox.RaterApiWrapper.Infrastructure.Data.Repositories;

public class StaticRatingFactorsRepository : RepositoryBase, IRatingFactorsRepository
{
    private readonly IStaticDatasets _staticDatasets;
    public StaticRatingFactorsRepository(ApplicationDbContext context, IMemoryCache memoryCache, IStaticDatasets staticDatasets,
            ILogger<RatingFactorsRepository> logger) : base(context, memoryCache, logger)
    {
        _staticDatasets = staticDatasets;
    }

    public async Task<IEnumerable<RatingFactorMaster>> GetRatingFactorBySection(string version, short sectionId)
    {
        return _staticDatasets.RatingFactorsList!
            .Where(_ => _.Version == version && _.SectionId == sectionId);
    }
    public async Task<RatingFactorMaster?> GetRatingFactorByQuestion(string version, short sectionId, short questionId)
    {
        return await _context.RatingFactor!
            .Where(_ => _.Version == version && _.SectionId == sectionId && _.QuestionId == questionId)
            .FirstOrDefaultAsync();
    }
}
