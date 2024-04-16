using InventoryDomain = Pavas.Domain.Executors.Inventory.Inventory;

namespace Pavas.API.EndPoints.Inventory.GetById;

public record GetByIdInventoryRequestResult(InventoryDomain Inventory);