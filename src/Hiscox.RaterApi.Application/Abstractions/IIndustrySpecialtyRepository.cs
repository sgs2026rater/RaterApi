// Copyright (c) Hiscox Insurance. All rights reserved.


// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApi.Domain.Entities;

namespace Hiscox.RaterApi.Application.Abstractions;

public interface IIndustrySpecialtyRepository
{
    Task<IEnumerable<IndustrySpecialty>> GetAll(string version);
    Task<IEnumerable<IndustrySpecialty>> GetAllFromCacheOrSource(string version);
}