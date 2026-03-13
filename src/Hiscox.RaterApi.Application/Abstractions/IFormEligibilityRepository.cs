// Copyright (c) Hiscox Insurance. All rights reserved.


// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApi.Domain.Entities;

namespace Hiscox.RaterApi.Application.Abstractions;

public interface IFormEligibilityRepository
{
    Task<IEnumerable<FormEligibility>> GetAll(string version);
    Task<IEnumerable<FormEligibility>> GetForIndustrySpeciality(string version, int industrySpecialtyId);
}