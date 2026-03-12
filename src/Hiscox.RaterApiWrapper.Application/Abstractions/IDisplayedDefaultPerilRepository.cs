// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApiWrapper.Domain.Entities;

namespace Hiscox.RaterApiWrapper.Application.Abstractions;

public interface IDisplayedDefaultPerilRepository
{
    Task<IEnumerable<DisplayedDefaultPeril>> GetAll(string version);
    Task<DisplayedDefaultPeril?> GetByPeril(string version, string peril);
}