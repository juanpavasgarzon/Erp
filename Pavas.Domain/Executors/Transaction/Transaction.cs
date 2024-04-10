using Pavas.Domain.Executors.Transaction.Constants;

namespace Pavas.Domain.Executors.Transaction;

public class Transaction(
    int id,
    int inventoryId,
    MovementType type,
    int quantity,
    DateTime movementDate,
    TransactionReason reason
)
{
    public int Id { get; set; } = id;
    public int InventoryId { get; set; } = inventoryId;
    public Inventory.Inventory Inventory { get; set; } = null!;
    public MovementType Type { get; set; } = type;
    public int Quantity { get; set; } = quantity;
    public DateTime MovementDate { get; set; } = movementDate;
    public TransactionReason Reason { get; set; } = reason;
}