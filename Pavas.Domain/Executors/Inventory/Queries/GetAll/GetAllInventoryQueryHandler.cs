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
        var result = await repository.GetByAsync<Inventory>(
            x => x.CompanyId == query.CompanyId,
            cancellationToken
        );
        return new GetAllInventoryQueryResult(result.ToList());
    }
}