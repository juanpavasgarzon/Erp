using Pavas.Abstractions.DatabaseContext.Contracts;
using Pavas.Abstractions.Dispatch.Queries.Contracts;

namespace Pavas.Domain.Executors.Inventory.Queries.GetAll;

public class GetAllInventoryQueryHandler(
    IRepository repository
) : IQueryHandler<GetAllInventoryQuery, GetAllInventoryQueryResult>
{
    public async Task<GetAllInventoryQueryResult> HandleAsync(
        GetAllInventoryQuery query,
        CancellationToken cancellationToken = default
    )
    {
        var result = (await repository.GetByAsync<Inventory>(
            x => x.CompanyId == query.CompanyId,
            cancellationToken
        )).OrderByDescending(x => x.Id).ToList();
        var items = result.Select(i => new InventoryQueryResultItem(
                i.Id,
                i.Code,
                i.Name,
                i.Description,
                i.Type.ToString(),
                i.Price,
                i.Quantity
            ))
            .OrderByDescending(x => x.Id)
            .ToList();

        return new GetAllInventoryQueryResult(items);
    }
}