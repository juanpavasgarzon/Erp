using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Pavas.Abstractions.Dispatch.Commands.Contracts;
using Pavas.API.MinimalApi;
using Pavas.Application.Executors.Inventory.Commands.Subtract;

namespace Pavas.API.EndPoints.Inventory.Subtract;

public class SubtractInventoryRequestHandler : AbstractEndPoint
{
    public override void Configure(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPatch("/inventories/subtract/{inventoryId:int}", HandleAsync)
            .WithTags("Inventory")
            .WithDescription("Endpoint To Remove Inventory");
    }

    private static async Task<IResult> HandleAsync(
        [FromServices] IValidator<SubtractInventoryRequest> validator,
        [FromServices] ICommandDispatcher dispatcher,
        [FromBody] SubtractInventoryRequest request,
        int inventoryId
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
            var command = new AppSubtractInventoryCommand(inventoryId, request.Quantity);
            await dispatcher.DispatchAsync(command);
            return TypedResults.NoContent();
        }
        catch (Exception e)
        {
            return GetErrorResult(e);
        }
    }
}