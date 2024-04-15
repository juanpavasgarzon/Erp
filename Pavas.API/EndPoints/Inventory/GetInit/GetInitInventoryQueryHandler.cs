using Microsoft.AspNetCore.Mvc;
using Pavas.Abstractions.Dispatch.Queries.Contracts;
using Pavas.API.MinimalApi;
using Pavas.Application.Executors.Inventory.Queries.GetInit;

namespace Pavas.API.EndPoints.Inventory.Get;

public class GetInitInventoryQueryHandler : AbstractEndPoint
{
    public override void Configure(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/inventories/init", HandleAsync)
            .WithTags("Inventory")
            .WithDescription("Endpoint To Get Init Inventory");
    }

    private static async Task<IResult> HandleAsync([FromServices] IQueryDispatcher dispatcher)
    {
        try
        {
            var result = await dispatcher.QueryAsync<AppGetInitInventoryQueryResult>();
            var response = new GetInitInventoryRequestResponse(result.InventoryTypes);
            return TypedResults.Ok(response);
        }
        catch (Exception e)
        {
            return GetErrorResult(e);
        }
    }
}