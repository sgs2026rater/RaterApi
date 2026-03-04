// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApiWrapper.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hiscox.RaterApiWrapper.Application.Abstractions;

public interface ILookupRepository
{
    Task<List<LimitRetentionFactor>> GetLimitRetentionFactor();
    Task<List<OccLimitFactor>> GetOccLimitFactor();
    Task<List<ProjectTypeFactor>> GetProjectTypeFactor();
    Task<List<RetainedValueFactor>> GetRetainedValueFactor();
    Task<List<RetainedValueFactorMatrix>> GetRetainedValueFactorMatrix();
    Task<List<RevenueBaseRate>> GetRevenueBaseRate();
    Task<List<OptionalCoreCoverage>> PopulateOptionalCoreCoverage();
}
