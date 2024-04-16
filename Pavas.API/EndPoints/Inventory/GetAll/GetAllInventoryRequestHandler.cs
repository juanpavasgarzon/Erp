using Microsoft.AspNetCore.Mvc;
using Pavas.Abstractions.Dispatch.Queries.Contracts;
using Pavas.API.MinimalApi;
using Pavas.Application.Executors.Inventory.Queries.GetAll;

namespace Pavas.API.EndPoints.Inventory.GetAll;

public class GetAllInventoryRequestHandler : AbstractEndPoint
{
    public override void Configure(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/inventories/by_company/{companyId:int}", HandleAsync)
            .WithTags("Inventory")
            .WithDescription("Endpoint To Get All Inventory");
    }

    private static async Task<IResult> HandleAsync([FromServices] IQueryDispatcher dispatcher, int companyId)
    {
        try
        {
            var query = new AppGetAllInventoryQuery(companyId);
            var result = await dispatcher.QueryAsync<AppGetAllInventoryQuery, AppGetAllInventoryQueryResult>(query);
            var items = result.Inventories.Select(i =>
                new InventoryRequestResponseItem(i.Id, i.Code, i.Name, i.Description, i.Type, i.Price, i.Quantity)
            ).ToList();
            var response = new GetAllInventoryRequestResponse(items);
            return TypedResults.Ok(response);
        }
        catch (Exception e)
        {
            return GetErrorResult(e);
        }
    }
}