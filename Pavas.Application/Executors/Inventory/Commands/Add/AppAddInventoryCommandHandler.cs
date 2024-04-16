using Pavas.Abstractions.DatabaseContext.Contracts;
using Pavas.Abstractions.Dispatch.Commands.Contracts;
using Pavas.Domain.Executors.Inventory.Commands.Add;
using Pavas.Domain.Executors.Inventory.Commands.Transaction;
using Pavas.Domain.Executors.Inventory.Constants;

namespace Pavas.Application.Executors.Inventory.Commands.Add;

public class AppAddInventoryCommandHandler(
    ICommandDispatcher dispatcher,
    IRepository repository
) : ICommandHandler<AppAddInventoryCommand>
{
    public async Task HandleAsync(AppAddInventoryCommand appCommand, CancellationToken cancellationToken = default)
    {
        var transaction = await repository.BeginTransactionAsync(cancellationToken);
        try
        {
            var command = new AddInventoryCommand(
                appCommand.Code,
                appCommand.Name,
                appCommand.Description,
                appCommand.CompanyId,
                appCommand.Type,
                appCommand.Price,
                appCommand.Quantity
            );
            var result = await dispatcher.DispatchAsync<AddInventoryCommand, AddInventoryCommandResult>(
                command,
                cancellationToken
            );

            var transactionCommand = new AddInventoryTransactionCommand(
                result.InventoryId,
                MovementType.In,
                command.Quantity,
                DateTime.Now,
                TransactionReason.DirectEntry
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