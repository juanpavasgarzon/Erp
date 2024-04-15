using Pavas.Abstractions.Dispatch.Queries.Contracts;

namespace Pavas.Domain.Executors.Inventory.Queries.GetAll;

public record GetAllInventoryQuery(int CompanyId) : IQuery;