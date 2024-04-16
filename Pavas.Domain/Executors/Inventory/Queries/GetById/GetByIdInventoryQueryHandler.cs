using Pavas.Abstractions.DatabaseContext.Contracts;
using Pavas.Abstractions.Dispatch.Queries.Contracts;
using Pavas.Abstractions.Exceptions;

namespace Pavas.Domain.Executors.Inventory.Queries.GetById;

public class GetByIdInventoryQueryHandler(
    IRepository repository
) : IQueryHandler<GetByIdInventoryQuery, GetByIdInventoryQueryResult>
{
    public async Task<GetByIdInventoryQueryResult> HandleAsync(
        GetByIdInventoryQuery query,
        CancellationToken cancellationToken = default
    )
    {
        var inventory = await repository.GetByIdAsync<Inventory, int>(query.InventoryId, cancellationToken);
        if (inventory is null)
        {
            throw new EntityNotFoundException($"Inventory With Id '{query.InventoryId}' Is Not Found");
        }

        return new GetByIdInventoryQueryResult(inventory);
    }
}