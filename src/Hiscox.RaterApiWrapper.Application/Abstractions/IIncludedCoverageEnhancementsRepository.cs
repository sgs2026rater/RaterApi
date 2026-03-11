// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApiWrapper.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hiscox.RaterApiWrapper.Application.Abstractions;

public interface IIncludedCoverageEnhancementsRepository
{
    Task<IEnumerable<IncludedCoverageEnhancements>> GetByForm(string version, string form);
}
