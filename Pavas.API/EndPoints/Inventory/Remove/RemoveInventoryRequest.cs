namespace Pavas.API.EndPoints.Inventory.Remove;

public record RemoveInventoryRequest(
    int Code,
    decimal Quantity
);