// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApiWrapper.Application.Services;
using Hiscox.RaterApiWrapper.Domain.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Hiscox.RaterApiWrapper.Application;

public static class DependencyInjection
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddTransient<IRaterService, RaterService>();
    }
}