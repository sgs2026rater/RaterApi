// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApi.Domain.Entities;

namespace Hiscox.RaterApi.Application.Abstractions;

public interface IMagicPolicyRepository
{
    Task<PolicyDetails?> GetByPolicyNumber(string version, string PolicyNumber);
}
