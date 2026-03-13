// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApi.Domain.Entities;

namespace Hiscox.RaterApi.Domain.Abstractions;

public interface IRaterService
{
    Task<Result<RaterResult, RaterFailureDetails>> GetRateInformation(RaterInputs raterInputs);
}