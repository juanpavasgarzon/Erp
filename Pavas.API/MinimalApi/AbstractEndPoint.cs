using Microsoft.EntityFrameworkCore;
using Pavas.Abstractions.Exceptions;
using Pavas.API.MinimalApi.Contracts;

namespace Pavas.API.MinimalApi;

public abstract class AbstractEndPoint : IEndpoint
{
    public abstract void Configure(IEndpointRouteBuilder endpoints);

    private static Exception GetLastInnerException(Exception exception)
    {
        while (exception.InnerException != null)
        {
            exception = exception.InnerException;
        }

        return exception;
    }

    protected static IResult GetErrorResult(Exception exception)
    {
        var originalException = GetLastInnerException(exception);

        if (exception is EntityAlreadyExistsException)
        {
            return TypedResults.Conflict<object>(new
            {
                message = exception.Message,
                orignalMessage = originalException.Message
            });
        }

        if (exception is EntityNotFoundException)
        {
            return TypedResults.NotFound<object>(new
            {
                message = exception.Message,
                orignalMessage = originalException.Message
            });
        }

        if (exception is DbUpdateException)
        {
            return TypedResults.Conflict<object>(new
            {
                message = exception.Message,
                orignalMessage = originalException.Message
            });
        }

        if (exception is NotAllowedException)
        {
            return TypedResults.Problem(
                detail: $"Message: {exception.Message}, Original: {originalException.Message}",
                statusCode: StatusCodes.Status406NotAcceptable
            );
        }

        return TypedResults.Problem(
            detail: $"Message: {exception.Message}, Original: {originalException.Message}",
            statusCode: StatusCodes.Status500InternalServerError
        );
    }
}