using InventoryDomain = Pavas.Domain.Executors.Inventory.Inventory;

namespace Pavas.Application.Executors.Inventory.Queries.GetById;

public record AppGetByIdInventoryQueryResult(InventoryDomain Inventory);