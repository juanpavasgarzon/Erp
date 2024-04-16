using InventoryDomain = Pavas.Domain.Executors.Inventory.Inventory;

namespace Pavas.Domain.Executors.Inventory.Queries.GetById;

public record GetByIdInventoryQueryResult(InventoryDomain Inventory);