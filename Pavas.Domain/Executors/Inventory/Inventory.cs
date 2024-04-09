namespace Pavas.Domain.Executors.Inventory;

public enum InventoryType
{
    Product,
    Service,
    Asset
}

public class Inventory(
    int id,
    string name,
    string description,
    InventoryType type,
    decimal price,
    int quantity,
    string location
)
{
    public int Id { get; set; } = id;
    public string Name { get; set; } = name;
    public string Description { get; set; } = description;
    public InventoryType Type { get; set; } = type;
    public decimal Price { get; set; } = price;
    public int Quantity { get; set; } = quantity;
    public string Location { get; set; } = location;
}