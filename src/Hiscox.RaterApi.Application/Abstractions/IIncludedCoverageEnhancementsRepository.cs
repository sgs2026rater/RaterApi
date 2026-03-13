// Copyright (c) Hiscox Insurance. All rights reserved.

namespace Hiscox.RaterApi.Application.Abstractions;

public interface IIncludedCoverageEnhancementsRepository
{
    Task<string?> GetCoverageEnhancementsByForm(string version, string form);
}
