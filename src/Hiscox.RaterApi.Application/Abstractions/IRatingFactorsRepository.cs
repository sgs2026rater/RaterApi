// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApi.Domain.Entities;

namespace Hiscox.RaterApi.Application.Abstractions;

public interface IRatingFactorsRepository
{
    Task<List<RatingFactorMaster>> GetRatingFactorBySection(string version, short sectionId);
    Task<RatingFactorMaster?> GetRatingFactorByQuestion(string version, short sectionId, short questionId);
}
