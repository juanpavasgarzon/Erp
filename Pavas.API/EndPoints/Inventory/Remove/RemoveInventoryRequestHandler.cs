using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pavas.Abstractions.Dispatch.Commands.Contracts;
using Pavas.API.MinimalApi;
using Pavas.Application.Executors.Inventory.Commands.Remove;

namespace Pavas.API.EndPoints.Inventory.Remove;

public class RemoveInventoryRequestHandler : AbstractEndPoint
{
    public override void Configure(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapDelete("/inventories", HandleAsync)
            .WithTags("Inventory")
            .WithDescription("Endpoint To Remove Inventory");
    }

    private static async Task<IResult> HandleAsync(
        [FromBody] RemoveInventoryRequest request,
        [FromServices] ICommandDispatcher dispatcher,
        [FromServices] IMapper mapper
    )
    {
        try
        {
            var command = mapper.Map<AppRemoveInventoryCommand>(request);
            await dispatcher.DispatchAsync(command);
            return TypedResults.Ok();
        }
        catch (Exception e)
        {
            return GetErrorResult(e);
        }
    }
}