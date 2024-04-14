using Pavas.Abstractions.Dispatch.Commands.Contracts;
using Pavas.Domain.Executors.Inventory.Constants;

namespace Pavas.Domain.Executors.Inventory.Commands.Transaction;

public record AddInventoryTransactionCommand(
    int inventoryId,
    MovementType type,
    decimal quantity,
    DateTime movementDate,
    TransactionReason reason
) : ICommand;