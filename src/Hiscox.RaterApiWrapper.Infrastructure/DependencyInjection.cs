// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApiWrapper.Application;
using Hiscox.RaterApiWrapper.Application.Abstractions;
using Hiscox.RaterApiWrapper.Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Hiscox.RaterApiWrapper.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IMagicPolicyRepository, MagicPolicyRepository>();
        services.AddScoped<IGeographicModRepository, GeographicModRepository>();
        services.AddScoped<IIndustrySectorRepository, IndustrySectorRepository>();
        services.AddScoped<IIndustrySubSectorRepository, IndustrySubSectorRepository>();
        services.AddScoped<IIndustrySpecialtyRepository, IndustrySpecialtyRepository>();
        services.AddScoped<IFormRepository, FormRepository>();
        services.AddScoped<IFormEligibilityRepository, FormEligibilityRepository>();
        services.AddScoped<IRatingFactorsRepository, RatingFactorsRepository>();
        services.AddScoped<ILimitRetentionFactorRepository, LimitRetentionFactorRepository>();
        services.AddScoped<IOptionalCoverageFactorsRepository, OptionalCoverageFactorsRepository>();
        services.AddScoped<IProjectTypeFactorRepository, ProjectTypeFactorRepository>();
        services.AddScoped<IRetainedValueFactorRepository, RetainedValueFactorRepository>();
        services.AddScoped<IRetainedValueFactorMatrixRepository, RetainedValueFactorMatrixRepository>();
        services.AddScoped<IRevenueBaseRateRepository, RevenueBaseRateRepository>();
        services.AddScoped<IIncludedCoverageEnhancementsRepository, IncludedCoverageEnhancementsRepository>();
        services.AddScoped<IOptCovTable1Repository, OptCovTable1Repository>();
        services.AddScoped<IOptionalCoverageTable1Repository, OptionalCoverageTable1Repository>();
    }
}