// Copyright (c) Hiscox Insurance. All rights reserved.

namespace Hiscox.RaterApi.Application.Abstractions;

public interface IGeographicModRepository
{
    Task<string> GetMetroArea(string version, string zipCode);
    Task<decimal> GetAE(string version, string zipCode);
}
