using AutoMapper;
using Pavas.Abstractions.Dispatch.Queries.Contracts;
using Pavas.Domain.Executors.Inventory.Queries.GetAll;

namespace Pavas.Application.Executors.Inventory.Queries.GetAll;

public class AppGetAllInventoryQueryHandler(
    IQueryDispatcher dispatcher,
    IMapper mapper
) : IQueryHandler<AppGetAllInventoryQuery, AppGetAllInventoryQueryResult>
{
    public async Task<AppGetAllInventoryQueryResult> HandleAsync(
        AppGetAllInventoryQuery appQuery,
        CancellationToken cancellationToken = default
    )
    {
        var query = mapper.Map<GetAllInventoryQuery>(appQuery);
        var result = await dispatcher.QueryAsync<GetAllInventoryQuery, GetAllInventoryQueryResult>(
            query,
            cancellationToken
        );
        return new AppGetAllInventoryQueryResult(result.Inventories);
    }
}