using AutoMapper;
using Pavas.Abstractions.Dispatch.Commands.Contracts;
using Pavas.API.MinimalApi;
using Pavas.Application.Executors.Inventory.Commands.Add;

namespace Pavas.API.EndPoints.Inventory.Add;

public class AddInventoryRequestHandler : AbstractEndPoint
{
    public override void Configure(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("/inventories", HandleAsync)
            .WithTags("Inventory")
            .WithDescription("Endpoint To Add Inventory");
    }

    private static async Task<IResult> HandleAsync(
        AddInventoryRequest request,
        ICommandDispatcher dispatcher,
        IMapper mapper
    )
    {
        try
        {
            var command = mapper.Map<AppAddInventoryCommand>(request);
            await dispatcher.DispatchAsync(command);
            return TypedResults.Ok();
        }
        catch (Exception e)
        {
            return GetErrorResult(e);
        }
    }
}