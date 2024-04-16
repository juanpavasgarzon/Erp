using Pavas.Abstractions.Dispatch.Queries.Contracts;

namespace Pavas.Domain.Executors.Inventory.Queries.GetById;

public record GetByIdInventoryQuery(int InventoryId) : IQuery;