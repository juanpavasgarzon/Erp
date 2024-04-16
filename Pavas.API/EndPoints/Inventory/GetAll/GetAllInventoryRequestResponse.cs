namespace Pavas.API.EndPoints.Inventory.GetAll;

public record InventoryRequestResponseItem(
    int Id,
    int Code,
    string Name,
    string Description,
    string Type,
    decimal Price,
    decimal Quantity
);

public record GetAllInventoryRequestResponse(List<InventoryRequestResponseItem> Inventories);