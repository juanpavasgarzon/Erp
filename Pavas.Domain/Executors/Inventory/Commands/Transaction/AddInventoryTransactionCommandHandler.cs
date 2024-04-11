using Pavas.Abstractions.DatabaseContext.Contracts;
using Pavas.Abstractions.Dispatch.Commands.Contracts;

namespace Pavas.Domain.Executors.Inventory.Commands.Transaction;

public class AddInventoryTransactionCommandHandler(
    IRepository repository
) : ICommandHandler<AddInventoryTransactionCommand>
{
    public async Task HandleAsync(AddInventoryTransactionCommand command, CancellationToken cancellationToken = default)
    {
        var transaction = new InventoryTransaction(
            command.inventoryId,
            command.type,
            command.quantity,
            command.movementDate,
            command.reason
        );

        await repository.AddAsync(transaction, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
    }
}