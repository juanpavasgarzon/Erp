using Pavas.Abstractions.Dispatch.Queries.Contracts;
using Pavas.Domain.Executors.Inventory.Queries.GetAll;

namespace Pavas.Application.Executors.Inventory.Queries.GetAll;

public class AppGetAllInventoryQueryHandler(
    IQueryDispatcher dispatcher
) : IQueryHandler<AppGetAllInventoryQuery, AppGetAllInventoryQueryResult>
{
    public async Task<AppGetAllInventoryQueryResult> HandleAsync(
        AppGetAllInventoryQuery appQuery,
        CancellationToken cancellationToken = default
    )
    {
        var query = new GetAllInventoryQuery(appQuery.CompanyId);
        var result = await dispatcher.QueryAsync<GetAllInventoryQuery, GetAllInventoryQueryResult>(
            query,
            cancellationToken
        );
        var items = result.Inventories.Select(i =>
            new AppInventoryQueryResultItem(i.Id, i.Code, i.Name, i.Description, i.Type, i.Price, i.Quantity)
        ).ToList();
        return new AppGetAllInventoryQueryResult(items);
    }
}