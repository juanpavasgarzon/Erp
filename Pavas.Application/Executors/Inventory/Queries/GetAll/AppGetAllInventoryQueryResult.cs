namespace Pavas.Application.Executors.Inventory.Queries.GetAll;

public record AppInventoryQueryResultItem(
    int Id,
    int Code,
    string Name,
    string Description,
    string Type,
    decimal Price,
    decimal Quantity
);

public record AppGetAllInventoryQueryResult(List<AppInventoryQueryResultItem> Inventories);