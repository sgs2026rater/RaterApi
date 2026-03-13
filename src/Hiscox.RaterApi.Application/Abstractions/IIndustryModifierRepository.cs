// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApi.Domain.Entities;

namespace Hiscox.RaterApi.Application.Abstractions;

public interface IIndustryModifierRepository
{
    Task<IEnumerable<IndustryModifier>> GetAll(string version);
    Task<decimal> GetNAICSModifierBySpecialty(string version, string specialty);
    Task<decimal> GetEOMimimumPremiumBySpecialty(string version, string specialty);
}