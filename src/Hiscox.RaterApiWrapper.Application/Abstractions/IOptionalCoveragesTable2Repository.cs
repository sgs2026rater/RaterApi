// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApiWrapper.Domain.Entities;

namespace Hiscox.RaterApiWrapper.Application.Abstractions;

public interface IOptionalCoveragesTable2Repository
{
    Task<IEnumerable<OptionalCoveragesTable2>> GetAll(string version);
    Task<OptionalCoveragesTable2?> GetByCoverage(string version, string coverage);
}