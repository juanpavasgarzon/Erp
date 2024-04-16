using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pavas.Abstractions.Exceptions;
using Pavas.API.MinimalApi.Contracts;

namespace Pavas.API.MinimalApi;

public abstract class AbstractEndPoint : IEndpoint
{
    public abstract void Configure(IEndpointRouteBuilder endpoints);
    
    protected static IResult GetErrorResult(Exception exception)
    {
        if (exception is BadRequestException)
        {
            return TypedResults.BadRequest<object>(new
            {
                Detail = exception.Message,
                Status = StatusCodes.Status400BadRequest
            });
        }

        if (exception is EntityAlreadyExistsException or DbUpdateException)
        {
            return TypedResults.Conflict<object>(new
            {
                Detail = exception.Message,
                Status = StatusCodes.Status409Conflict
            });
        }

        if (exception is EntityNotFoundException)
        {
            return TypedResults.NotFound<object>(new
            {
                Detail = exception.Message,
                Status = StatusCodes.Status404NotFound
            });
        }

        if (exception is NotAllowedException)
        {
            return TypedResults.Problem(new ProblemDetails
            {
                Detail = exception.Message,
                Status = StatusCodes.Status406NotAcceptable
            });
        }

        return TypedResults.Problem(new ProblemDetails
        {
            Detail = exception.Message,
            Status = StatusCodes.Status500InternalServerError
        });
    }
}