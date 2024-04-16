using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Pavas.Abstractions.Dispatch.Commands.Contracts;
using Pavas.API.MinimalApi;
using Pavas.Application.Executors.Customer.Commands.Add;

namespace Pavas.API.EndPoints.Customer.Add;

public class AddCustomerRequestHandler : AbstractEndPoint
{
    public override void Configure(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("/customers/add", HandleAsync)
            .WithTags("Customer")
            .WithDescription("Endpoint To Create One Customer");
    }

    private static async Task<IResult> HandleAsync(
        [FromServices] IValidator<AddCustomerRequest> validator,
        [FromServices] ICommandDispatcher dispatcher,
        [FromBody] AddCustomerRequest request
    )
    {
        var validationResult = await validator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            return TypedResults.BadRequest<object>(new
            {
                Detail = validationResult.ToDictionary(),
                Status = StatusCodes.Status400BadRequest
            });
        }

        try
        {
            var command = new AppAddCustomerCommand(
                request.Id,
                request.FirstName,
                request.LastName,
                request.Email,
                request.PhoneNumber
            );
            await dispatcher.DispatchAsync(command);
            return TypedResults.Created();
        }
        catch (Exception e)
        {
            return GetErrorResult(e);
        }
    }
}