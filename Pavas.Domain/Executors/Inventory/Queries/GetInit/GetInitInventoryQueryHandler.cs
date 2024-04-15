using Pavas.Abstractions.Dispatch.Queries.Contracts;
using Pavas.Domain.Executors.Inventory.Constants;

namespace Pavas.Domain.Executors.Inventory.Queries.GetInit;

public class GetInitInventoryQueryHandler : IQueryHandler<GetInitInventoryQueryResult>
{
    public async Task<GetInitInventoryQueryResult> HandleAsync(CancellationToken cancellationToken = default)
    {
        var task = new Task<GetInitInventoryQueryResult>(() =>
        {
            return new GetInitInventoryQueryResult(Enum.GetValues(typeof(InventoryType))
                .Cast<Enum>()
                .Select(e => new { value = Convert.ToInt32(e), label = e.ToString() })
                .ToList<object>());
        }, cancellationToken);
        task.Start();
        return await task;
    }
}