using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pavas.Abstractions.Dispatch.Queries;
using Pavas.API.MinimalApi;
using Pavas.Application.Executors.Inventory.Queries.GetAll;

namespace Pavas.API.EndPoints.Inventory.GetAll;

public class GetAllInventoryRequestHandler : AbstractEndPoint
{
    public override void Configure(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/inventories", HandleAsync)
            .WithTags("Inventory")
            .WithDescription("Endpoint To Get All Inventory");
    }

    private static async Task<IResult> HandleAsync(
        [FromBody] GetAllInventoryRequest request,
        [FromServices] QueryDispatcher dispatcher,
        [FromServices] IMapper mapper
    )
    {
        try
        {
            var query = mapper.Map<AppGetAllInventoryQuery>(request);
            var result = await dispatcher.QueryAsync<AppGetAllInventoryQuery, AppGetAllInventoryQueryResult>(query);
            var response = new GetAllInventoryRequestResponse(result.Inventories);
            return TypedResults.Ok(response);
        }
        catch (Exception e)
        {
            return GetErrorResult(e);
        }
    }
}