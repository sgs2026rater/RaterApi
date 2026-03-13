// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApi.Domain.Entities;

namespace Hiscox.RaterApi.Application.Abstractions;

public interface IDataValidationRepository
{
    Task<IEnumerable<DataValidation>> GetAll(string version);
    Task<DataValidation?> GetByPeril(string version, string peril);
}