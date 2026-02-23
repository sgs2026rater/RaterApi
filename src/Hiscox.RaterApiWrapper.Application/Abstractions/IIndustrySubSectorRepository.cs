// Copyright (c) Hiscox Insurance. All rights reserved.


// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApiWrapper.Domain.Entities;

namespace Hiscox.RaterApiWrapper.Application.Abstractions;

public interface IIndustrySubSectorRepository
{
    Task<IEnumerable<IndustrySubSector>> GetAll(string version);
    Task<IEnumerable<IndustrySubSector>> GetAllFromCacheOrSource(string version);
}