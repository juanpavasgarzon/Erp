using Pavas.Abstractions.Dispatch.Queries.Contracts;

namespace Pavas.Application.Executors.Inventory.Queries.GetById;

public record AppGetByIdInventoryQuery(int InventoryId) : IQuery;