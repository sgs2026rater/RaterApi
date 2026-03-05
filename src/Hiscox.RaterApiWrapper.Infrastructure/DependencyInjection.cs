// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApiWrapper.Application;
using Hiscox.RaterApiWrapper.Application.Abstractions;
using Hiscox.RaterApiWrapper.Application.Abstractions;
using Hiscox.RaterApiWrapper.Infrastructure.Data;
using Hiscox.RaterApiWrapper.Infrastructure.Data.Repositories;
using Hiscox.RaterApiWrapper.Infrastructure.Data.StaticRepositories;
using Microsoft.Extensions.DependencyInjection;
namespace Hiscox.RaterApiWrapper.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IPolicyRepository, StaticPolicyRepository>();
        services.AddScoped<IGeographicModRepository, StaticGeographicModRepository>();        
        services.AddScoped<IIndustrySectorRepository, StaticIndustrySectorRepository>();
        services.AddScoped<IIndustrySubSectorRepository, StaticIndustrySubSectorRepository>();
        services.AddScoped<IIndustrySpecialtyRepository, StaticIndustrySpecialtyRepository>();
        services.AddScoped<IRatingFactorsRepository, RatingFactorsRepository>();
        services.AddScoped<ILookupRepository, LookupRepository>();
        services.AddSingleton<IStaticDatasets, StaticDatasets>();
    }
}