// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApi.Domain.Entities;

namespace Hiscox.RaterApi.Application.Abstractions;

public interface IDisplayedDefaultPerilRepository
{
    Task<IEnumerable<DisplayedDefaultPeril>> GetAll(string version);
    Task<DisplayedDefaultPeril?> GetByPeril(string version, string peril);
}