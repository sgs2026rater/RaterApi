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
        services.AddScoped<IIndustrySectorRepository, IndustrySectorRepository>();
        services.AddScoped<IIndustrySubSectorRepository, IndustrySubSectorRepository>();
        services.AddScoped<IIndustrySpecialtyRepository, IndustrySpecialtyRepository>();
    }
}