// Copyright (c) Hiscox Insurance. All rights reserved.

using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hiscox.RaterApiWrapper.Presentation.Api.MIddleware;

public class GlobalExeptionHandler: IExceptionHandler
{
    private readonly ILogger _logger;

    public GlobalExeptionHandler(
        ILogger<GlobalExeptionHandler> logger)
    {
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        _logger.LogError(exception, "An unhandled exception occurred while processing the request: {0}", exception.Message);
        var problemDetails = new ProblemDetails
        {
            Status = StatusCodes.Status500InternalServerError,
            Title = "An unexpected error occurred.",
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1",
        };
        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        await httpContext.Response.WriteAsJsonAsync(problemDetails,cancellationToken );

        return true;
    }
}