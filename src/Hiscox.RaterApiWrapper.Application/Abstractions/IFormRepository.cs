// Copyright (c) Hiscox Insurance. All rights reserved.


// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApiWrapper.Domain.Entities;

namespace Hiscox.RaterApiWrapper.Application.Abstractions;

public interface IFormRepository
{
    Task<IEnumerable<Form>> GetAll(string version);
    Task<IEnumerable<Form>> GetAllFromCacheOrSource(string version);
}