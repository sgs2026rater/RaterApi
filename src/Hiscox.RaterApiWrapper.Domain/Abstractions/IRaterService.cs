// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApiWrapper.Domain.Entities;

namespace Hiscox.RaterApiWrapper.Domain.Abstractions;

public interface IRaterService
{
    Task<Result<RaterResult, RaterFailureDetails>> GetRateInformation(RaterInputs raterInputs);
}