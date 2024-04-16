namespace Pavas.Domain.Executors.Inventory.Queries.GetAll;
public record InventoryQueryResultItem(
    int Id,
    int Code,
    string Name,
    string Description,
    string Type,
    decimal Price,
    decimal Quantity
);
public record GetAllInventoryQueryResult(List<InventoryQueryResultItem> Inventories);