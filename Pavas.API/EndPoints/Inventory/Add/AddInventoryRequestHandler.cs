using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Pavas.Abstractions.Dispatch.Commands.Contracts;
using Pavas.API.MinimalApi;
using Pavas.Application.Executors.Inventory.Commands.Add;

namespace Pavas.API.EndPoints.Inventory.Add;

public class AddInventoryRequestHandler : AbstractEndPoint
{
    public override void Configure(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("/inventories/add", HandleAsync)
            .WithTags("Inventory")
            .WithDescription("Endpoint To Add Inventory");
    }

    private static async Task<IResult> HandleAsync(
        [FromServices] IValidator<AddInventoryRequest> validator,
        [FromServices] ICommandDispatcher dispatcher,
        [FromBody] AddInventoryRequest request
    )
    {
        var validationResult = await validator.ValidateAsync(request);
        if (validationResult.Errors is not null)
        {
            return TypedResults.BadRequest<object>(new
            {
                Detail = validationResult.ToDictionary(),
                Status = StatusCodes.Status400BadRequest
            });
        }

        try
        {
            var command = new AppAddInventoryCommand(
                request.Code,
                request.Name,
                request.Description,
                request.CompanyId,
                request.Type,
                request.Price,
                request.Quantity
            );
            await dispatcher.DispatchAsync(command);
            return TypedResults.NoContent();
        }
        catch (Exception e)
        {
            return GetErrorResult(e);
        }
    }
}