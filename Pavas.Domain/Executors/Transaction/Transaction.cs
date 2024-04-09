namespace Pavas.Domain.Executors.Transaction;

public enum TransactionReason
{
    Sale,
    Purchase,
    Loss,
    Barter,
    StockAdjustment,
    Expiration,
    Donation,
    WarrantyReceipt,
}

public enum MovementType
{
    In,
    Out
}

public class Transaction(
    int id,
    int inventoryId,
    MovementType type,
    int quantity,
    DateTime movementDate,
    TransactionReason reason
)
{
    public int Id { get; set; }
    public int InventoryId { get; set; }
    public Executors.Inventory.Inventory Inventory { get; set; } = null!;
    public MovementType Type { get; set; }
    public int Quantity { get; set; }
    public DateTime MovementDate { get; set; }
    public TransactionReason Reason { get; set; }
}