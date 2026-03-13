// Copyright (c) Hiscox Insurance. All rights reserved.


// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApi.Domain.Entities;

namespace Hiscox.RaterApi.Application.Abstractions;

public interface IFormRepository
{
    Task<IEnumerable<Form>> GetAll(string version);
    Task<IEnumerable<Form>> GetAllFromCacheOrSource(string version);
}