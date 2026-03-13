// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApiWrapper.Domain.Entities;

namespace Hiscox.RaterApiWrapper.Application.Abstractions;

public interface IIndustryModifierRepository
{
    Task<IEnumerable<IndustryModifier>> GetAll(string version);
    Task<decimal> GetNAICSModifierBySpecialty(string version, string specialty);
    Task<decimal> GetEOMimimumPremiumBySpecialty(string version, string specialty);
}