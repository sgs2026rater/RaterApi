// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApi.Domain.Entities;

namespace Hiscox.RaterApi.Application.Abstractions;

public interface IBusinessSizeDefinitionRepository
{
    Task<IEnumerable<BusinessSizeDefinition>> GetAll(string version);
    Task<BusinessSizeDefinition?> GetByRevenue(string version, decimal revenue);
}