// Copyright (c) Hiscox Insurance. All rights reserved.


// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApiWrapper.Domain.Entities;

namespace Hiscox.RaterApiWrapper.Application.Abstractions;

public interface IIndustrySpecialtyRepository
{
    Task<IEnumerable<IndustrySpecialty>> GetAll(string version);
    Task<IEnumerable<IndustrySpecialty>> GetAllFromCacheOrSource(string version);
}