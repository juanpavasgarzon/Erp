using Pavas.Domain.Executors.Inventory.Constants;

namespace Pavas.API.EndPoints.Inventory.Add;

public record AddInventoryRequest(
    int Code,
    string Name,
    string Description,
    int CompanyId,
    InventoryType Type,
    decimal Price,
    int Quantity
);