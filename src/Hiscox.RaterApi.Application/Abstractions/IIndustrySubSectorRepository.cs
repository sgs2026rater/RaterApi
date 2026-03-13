// Copyright (c) Hiscox Insurance. All rights reserved.


// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApi.Domain.Entities;

namespace Hiscox.RaterApi.Application.Abstractions;

public interface IIndustrySubSectorRepository
{
    Task<IEnumerable<IndustrySubSector>> GetAll(string version);
    Task<IEnumerable<IndustrySubSector>> GetAllFromCacheOrSource(string version);
}