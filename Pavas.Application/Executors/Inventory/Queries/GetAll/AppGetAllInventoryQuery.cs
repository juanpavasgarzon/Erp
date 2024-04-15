using Pavas.Abstractions.Dispatch.Queries.Contracts;

namespace Pavas.Application.Executors.Inventory.Queries.GetAll;

public record AppGetAllInventoryQuery(int CompanyId) : IQuery;