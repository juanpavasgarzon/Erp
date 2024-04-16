using Pavas.Abstractions.DatabaseContext.Contracts;
using Pavas.Abstractions.Dispatch.Commands.Contracts;
using Pavas.Domain.Executors.Inventory.Commands.Subtract;
using Pavas.Domain.Executors.Inventory.Commands.Transaction;
using Pavas.Domain.Executors.Inventory.Constants;

namespace Pavas.Application.Executors.Inventory.Commands.Subtract;

public class AppSubtractInventoryCommandHandler(
    ICommandDispatcher dispatcher,
    IRepository repository
) : ICommandHandler<AppSubtractInventoryCommand>
{
    public async Task HandleAsync(AppSubtractInventoryCommand appCommand, CancellationToken cancellationToken = default)
    {
        var transaction = await repository.BeginTransactionAsync(cancellationToken);
        try
        {
            var command = new SubtractInventoryCommand(appCommand.InventoryId, appCommand.Quantity);
            var result = await dispatcher.DispatchAsync<SubtractInventoryCommand, SubtractInventoryCommandResult>(
                command,
                cancellationToken
            );

            var transactionCommand = new AddInventoryTransactionCommand(
                result.InventoryId,
                MovementType.Out,
                command.Quantity,
                DateTime.Now,
                TransactionReason.DirectOutput
            );
            await dispatcher.DispatchAsync(transactionCommand, cancellationToken);
            await transaction.CommitAsync();
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}