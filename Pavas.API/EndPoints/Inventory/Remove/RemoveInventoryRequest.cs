namespace Pavas.API.EndPoints.Inventory.Remove;

public record RemoveInventoryRequest(
    int Code,
    int Quantity
);