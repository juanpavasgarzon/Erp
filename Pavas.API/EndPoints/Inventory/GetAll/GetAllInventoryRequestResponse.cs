using InventoryDomain = Pavas.Domain.Executors.Inventory.Inventory;

namespace Pavas.API.EndPoints.Inventory.GetAll;

public record GetAllInventoryRequestResponse(List<InventoryDomain> Inventories);