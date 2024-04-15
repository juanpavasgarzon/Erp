using InventoryDomain = Pavas.Domain.Executors.Inventory.Inventory;

namespace Pavas.Application.Executors.Inventory.Queries.GetAll;

public record AppGetAllInventoryQueryResult(List<InventoryDomain> Inventories);