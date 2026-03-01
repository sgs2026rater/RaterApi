// Copyright (c) Hiscox Insurance. All rights reserved.


// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApiWrapper.Domain.Entities;

namespace Hiscox.RaterApiWrapper.Application.Abstractions;

public interface IFormEligibilityRepository
{
    Task<IEnumerable<FormEligibility>> GetAll(string version);
    Task<IEnumerable<FormEligibility>> GetForIndustrySpeciality(string version, int industrySpecialtyId);
}