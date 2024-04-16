using Pavas.Abstractions.Dispatch.Queries.Contracts;
using Pavas.Domain.Executors.Inventory.Queries.GetInit;

namespace Pavas.Application.Executors.Inventory.Queries.GetInit;

public class AppGetInitInventoryQueryHandler(
    IQueryDispatcher dispatcher
) : IQueryHandler<AppGetInitInventoryQueryResult>
{
    public async Task<AppGetInitInventoryQueryResult> HandleAsync(CancellationToken cancellationToken = default)
    {
        var result = await dispatcher.QueryAsync<GetInitInventoryQueryResult>(cancellationToken);
        return new AppGetInitInventoryQueryResult(result.InventoryTypes);
    }
}