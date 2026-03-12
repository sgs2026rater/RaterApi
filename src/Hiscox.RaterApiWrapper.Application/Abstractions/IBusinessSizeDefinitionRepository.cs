// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApiWrapper.Domain.Entities;

namespace Hiscox.RaterApiWrapper.Application.Abstractions;

public interface IBusinessSizeDefinitionRepository
{
    Task<IEnumerable<BusinessSizeDefinition>> GetAll(string version);
    Task<BusinessSizeDefinition?> GetByRevenue(string version, decimal revenue);
}