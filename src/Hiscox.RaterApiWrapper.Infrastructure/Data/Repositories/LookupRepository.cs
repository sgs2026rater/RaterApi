// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApiWrapper.Application.Abstractions;
using Hiscox.RaterApiWrapper.Domain.Entities;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Hiscox.RaterApiWrapper.Infrastructure.Data.Repositories;

public class LookupRepository : RepositoryBase,  ILookupRepository
{
    public LookupRepository(ApplicationDbContext context, IMemoryCache memoryCache,
            ILogger<LookupRepository> logger) : base(context, memoryCache, logger)
    {
    }
    public async Task<List<LimitRetentionFactor>> GetLimitRetentionFactor()
    {
        var json = await GetJsonFromFile(@"Lookups\LimitRetentionFactor.txt");

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        List<LimitRetentionFactor>? items =
            JsonSerializer.Deserialize<List<LimitRetentionFactor>>(json, options);

        if (items == null)
        {
            throw new InvalidOperationException("Deserialization failed.");
        }

        return items;
    }
    public async Task<List<OccLimitFactor>> GetOccLimitFactor()
    {
        var json = await GetJsonFromFile(@"Lookups\OccLimitFactor.txt");

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        List<OccLimitFactor>? items =
            JsonSerializer.Deserialize<List<OccLimitFactor>>(json, options);

        if (items == null)
        {
            throw new InvalidOperationException("Deserialization failed.");
        }

        return items;
    }
    public async Task<List<ProjectTypeFactor>> GetProjectTypeFactor()
    {
        var json = await GetJsonFromFile(@"Lookups\ProjectTypeFactor.txt");

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        List<ProjectTypeFactor>? items =
            JsonSerializer.Deserialize<List<ProjectTypeFactor>>(json, options);

        if (items == null)
        {
            throw new InvalidOperationException("Deserialization failed.");
        }

        return items;
    }
    public async Task<List<RetainedValueFactor>> GetRetainedValueFactor()
    {
        var json = await GetJsonFromFile(@"Lookups\RetainedValueFactor.txt");

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        List<RetainedValueFactor>? items =
            JsonSerializer.Deserialize<List<RetainedValueFactor>>(json, options);

        if (items == null)
        {
            throw new InvalidOperationException("Deserialization failed.");
        }

        return items;
    }
    public async Task<List<RetainedValueFactorMatrix>> GetRetainedValueFactorMatrix()
    {
        var json = await GetJsonFromFile(@"Lookups\RetainedValueFactorMatrix.txt");

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        List<RetainedValueFactorMatrix>? items =
            JsonSerializer.Deserialize<List<RetainedValueFactorMatrix>>(json, options);

        if (items == null)
        {
            throw new InvalidOperationException("Deserialization failed.");
        }

        return items;
    }
    public async Task<List<RevenueBaseRate>> GetRevenueBaseRate()
    {
        var json = await GetJsonFromFile(@"Lookups\RevenueBaseRate.txt");

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        List<RevenueBaseRate>? items =
            JsonSerializer.Deserialize<List<RevenueBaseRate>>(json, options);

        if (items == null)
        {
            throw new InvalidOperationException("Deserialization failed.");
        }

        return items;
    }
    public async Task<List<OptionalCoreCoverage>> PopulateOptionalCoreCoverage()
    {
        var optionalCoreCoverages = new List<OptionalCoreCoverage>
        {
            new OptionalCoreCoverage
            {
                CoverageName = "Bodily Injury",
                SelectionInRater = "Full",
                ValueToUse = 1_000_000m,
                PercentOfOccLimit = 1.00m,
                LowLookupValue = 1.00m,
                HighLookupValue = 1.05m,
                LowCoefficient = 0.1974m,
                HighCoefficient = 0.20m,
                ValueOfInsurance = 0.1974m
            },
            new OptionalCoreCoverage
            {
                CoverageName = "Property Damage",
                SelectionInRater = "Full",
                ValueToUse = 1_000_000m,
                PercentOfOccLimit = 1.00m,
                LowLookupValue = 1.00m,
                HighLookupValue = 1.05m,
                LowCoefficient = 0.0790m,
                HighCoefficient = 0.08m,
                ValueOfInsurance = 0.0790m
            },
            new OptionalCoreCoverage
            {
                CoverageName = "Breach of Contract",
                SelectionInRater = "0",
                ValueToUse = null,
                PercentOfOccLimit = 0.00m,
                LowLookupValue = 0.00m,
                HighLookupValue = 0.03m,
                LowCoefficient = 0.00m,
                HighCoefficient = 0.01m,
                ValueOfInsurance = 0.00m
            },
            new OptionalCoreCoverage
            {
                CoverageName = "Personal & Advertising Injury",
                SelectionInRater = "0",
                ValueToUse = null,
                PercentOfOccLimit = 0.00m,
                LowLookupValue = 0.00m,
                HighLookupValue = 0.03m,
                LowCoefficient = 0.00m,
                HighCoefficient = 0.03m,
                ValueOfInsurance = 0.00m
            },
            new OptionalCoreCoverage
            {
                CoverageName = "Intellectual Property Infringement",
                SelectionInRater = "Full",
                ValueToUse = 1_000_000m,
                PercentOfOccLimit = 1.00m,
                LowLookupValue = 1.00m,
                HighLookupValue = 1.05m,
                LowCoefficient = 0.0790m,
                HighCoefficient = 0.08m,
                ValueOfInsurance = 0.0790m
            },
            new OptionalCoreCoverage
            {
                CoverageName = "Third Party Discrimination",
                SelectionInRater = "0",
                ValueToUse = null,
                PercentOfOccLimit = 0.00m,
                LowLookupValue = 0.00m,
                HighLookupValue = 0.03m,
                LowCoefficient = 0.00m,
                HighCoefficient = 0.01m,
                ValueOfInsurance = 0.00m
            }
        };

        return optionalCoreCoverages;
    }
    private async static Task<string> GetJsonFromFile(string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"File not found: {filePath}");
        }

        return await File.ReadAllTextAsync(filePath);
    }
}
