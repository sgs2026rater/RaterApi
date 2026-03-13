// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApi.Application.Services;
using Hiscox.RaterApi.Domain.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Hiscox.RaterApi.Application;

public static class DependencyInjection
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddTransient<IRaterService, RaterService>();
    }
}