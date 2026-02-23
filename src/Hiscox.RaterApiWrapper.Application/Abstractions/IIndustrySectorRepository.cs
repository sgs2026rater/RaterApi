// Copyright (c) Hiscox Insurance. All rights reserved.


// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApiWrapper.Domain.Entities;

namespace Hiscox.RaterApiWrapper.Application.Abstractions;

public interface IIndustrySectorRepository
{
    Task<IEnumerable<IndustrySector>> GetAll(string version);
    Task<IEnumerable<IndustrySector>> GetAllFromCacheOrSource(string version);
}