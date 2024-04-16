using Pavas.Abstractions.Dispatch.Queries.Contracts;
using Pavas.Domain.Executors.Inventory.Queries.GetById;

namespace Pavas.Application.Executors.Inventory.Queries.GetById;

public class AppGetByIdInventoryQueryHandler(
    IQueryDispatcher dispatcher
) : IQueryHandler<AppGetByIdInventoryQuery, AppGetByIdInventoryQueryResult>
{
    public async Task<AppGetByIdInventoryQueryResult> HandleAsync(
        AppGetByIdInventoryQuery appQuery,
        CancellationToken cancellationToken = default
    )
    {
        var query = new GetByIdInventoryQuery(appQuery.InventoryId);
        var result = await dispatcher.QueryAsync<GetByIdInventoryQuery, GetByIdInventoryQueryResult>(
            query,
            cancellationToken
        );
        return new AppGetByIdInventoryQueryResult(result.Inventory);
    }
}