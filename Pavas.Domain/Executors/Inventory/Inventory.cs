using Pavas.Domain.Executors.Inventory.Constants;

namespace Pavas.Domain.Executors.Inventory;

public class Inventory(
    int code,
    string name,
    string description,
    int companyId,
    InventoryType type,
    decimal price,
    int quantity
)
{
    public int Id { get; set; }
    public int Code { get; set; } = code;
    public string Name { get; set; } = name;
    public string Description { get; set; } = description;
    public int CompanyId { get; set; } = companyId;
    public Company.Company Company { get; set; } = null!;
    public InventoryType Type { get; set; } = type;
    public decimal Price { get; set; } = price;
    public int Quantity { get; set; } = quantity;
    public List<InventoryTransaction> Transactions { get; init; } = [];
}