using Pavas.Domain.Executors.Inventory.Constants;

namespace Pavas.Domain.Executors.Inventory;

public class InventoryTransaction(
    int inventoryId,
    MovementType type,
    decimal quantity,
    DateTime movementDate,
    TransactionReason reason
)
{
    public int Id { get; set; }
    public int InventoryId { get; set; } = inventoryId;
    public Inventory Inventory { get; set; } = null!;
    public MovementType Type { get; set; } = type;
    public decimal Quantity { get; set; } = quantity;
    public DateTime MovementDate { get; set; } = movementDate;
    public TransactionReason Reason { get; set; } = reason;
}