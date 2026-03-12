// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApiWrapper.Domain.Entities;

namespace Hiscox.RaterApiWrapper.Application.Abstractions;

public interface IDataValidationRepository
{
    Task<IEnumerable<DataValidation>> GetAll(string version);
    Task<DataValidation?> GetByPeril(string version, string peril);
}