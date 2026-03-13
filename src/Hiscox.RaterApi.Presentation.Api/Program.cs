// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApi.Application;
using Hiscox.RaterApi.Domain.Configuration;
using Hiscox.RaterApi.Infrastructure;
using Hiscox.RaterApi.Infrastructure.Data;
using Hiscox.RaterApi.Presentation.Api.Endpoints;
using Hiscox.RaterApi.Presentation.Api.MIddleware;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddExceptionHandler<GlobalExeptionHandler>();
builder.Services.AddProblemDetails();

BuildLogger(builder);
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.PropertyNamingPolicy = null; // Keep original casing
});

builder.AddServiceDefaults();


builder.Services.AddMemoryCache();
builder.Services.AddOpenApi();
builder.Services.AddValidation();


var app = builder.Build();
app.UseExceptionHandler();

app.MapDefaultEndpoints();

RaterEndpoint.Map(app);

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "Open API");
    });
}

app.UseHttpsRedirection();

await app.RunAsync();


void BuildLogger(IHostApplicationBuilder builder)
{
    var assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
    Log.Logger = new LoggerConfiguration()
        .WriteTo.File(@$"C:\logs\{assemblyName}\log.txt", rollingInterval: RollingInterval.Day) // Logs to a file with daily rolling
        .WriteTo.Console() // Logs to the console
        .CreateLogger();

    builder.Logging.ClearProviders(); // Remove default logging providers
    builder.Logging.AddSerilog();    // Add Serilog as the logging 
    builder.Services.Configure<RaterOptions>(builder.Configuration.GetSection("Rater"));
}
