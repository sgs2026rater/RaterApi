// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApiWrapper.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hiscox.RaterApiWrapper.Application.Abstractions;

public interface IRatingFactorsRepository
{
    Task<IEnumerable<RatingFactorMaster>> GetRatingFactorBySection(string version, short sectionId);
    Task<RatingFactorMaster?> GetRatingFactorByQuestion(string version, short sectionId, short questionId);
}
