// Copyright (c) Hiscox Insurance. All rights reserved.

using Hiscox.RaterApi.Domain.Abstractions;
using Hiscox.RaterApi.Domain.Entities;
using Hiscox.RaterApi.Presentation.Api.Contracts;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Hiscox.RaterApi.Presentation.Api.Endpoints;

public static class RaterEndpoint
{
    public static void Map(WebApplication app)
    {

        app.MapPost("api/rater", async ([FromBody] RaterRequest request, IRaterService raterService, ILogger<Program> logger) =>
        {
            var raterInputs = request.Adapt<RaterInputs>();
            // Ensure nested AdditionalRiskProfile is set on the domain input and propagate trustees-specific value
            if (request.AdditionalRiskProfile != null)
            {
                raterInputs.AdditionalRiskProfile ??= new AdditionalRiskProfile();
                raterInputs.AdditionalRiskProfile.AlternativeExposureBase_Trustees = request.AdditionalRiskProfile.AlternativeExposureBase_Trustees;
            }

            var response = await raterService.GetRateInformation(raterInputs);
            if (response.IsSuccess)
            {
                var raterResponse = response.Value.Adapt<RaterResponse>();
                return Results.Ok(raterResponse);
            }
            else
            {
                logger.LogWarning("Failed to get rate information for policy number {0}. {1}.", request.PolicyNumber, response.Error!.Description);
                return Results.Problem(statusCode: StatusCodes.Status400BadRequest, title: "Failed to get rate information", detail: response.Error!.Description);
            }
        })
        .Produces<RaterResponse>()
        .WithName("GetRateInformation")
           .AddOpenApiOperationTransformer((operation, context, ct) =>
           {
               operation.Summary = "Rater API";
               operation.Description = "Returns the rate information for a quote";
               return Task.CompletedTask;
           });
    }
}