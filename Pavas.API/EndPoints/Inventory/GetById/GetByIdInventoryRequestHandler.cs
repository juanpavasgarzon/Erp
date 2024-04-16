using Pavas.Abstractions.Dispatch.Queries.Contracts;
using Pavas.API.MinimalApi;
using Pavas.Application.Executors.Inventory.Queries.GetById;

namespace Pavas.API.EndPoints.Inventory.GetById;

public class GetByIdInventoryRequestHandler : AbstractEndPoint
{
    public override void Configure(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/inventories/{inventoryId:int}", HandleAsync)
            .WithTags("Inventory")
            .WithDescription("Endpoint To Get One Inventory By Id");
    }

    private static async Task<IResult> HandleAsync(IQueryDispatcher dispatcher, int inventoryId)
    {
        try
        {
            var query = new AppGetByIdInventoryQuery(inventoryId);
            var result = await dispatcher.QueryAsync<AppGetByIdInventoryQuery, AppGetByIdInventoryQueryResult>(query);
            var response = new GetByIdInventoryRequestResult(result.Inventory);
            return TypedResults.Ok(response);
        }
        catch (Exception e)
        {
            return GetErrorResult(e);
        }
    }
}