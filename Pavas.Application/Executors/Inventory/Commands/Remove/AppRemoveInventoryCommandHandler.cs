using AutoMapper;
using Pavas.Abstractions.DatabaseContext.Contracts;
using Pavas.Abstractions.Dispatch.Commands.Contracts;
using Pavas.Domain.Executors.Inventory.Commands.Remove;
using Pavas.Domain.Executors.Inventory.Commands.Transaction;
using Pavas.Domain.Executors.Inventory.Constants;

namespace Pavas.Application.Executors.Inventory.Commands.Remove;

public class AppRemoveInventoryCommandHandler(
    ICommandDispatcher dispatcher,
    IMapper mapper,
    IRepository repository
) : ICommandHandler<AppRemoveInventoryCommand>
{
    public async Task HandleAsync(AppRemoveInventoryCommand appCommand, CancellationToken cancellationToken = default)
    {
        var transaction = await repository.BeginTransactionAsync(cancellationToken);
        try
        {
            var command = mapper.Map<RemoveInventoryCommand>(appCommand);
            var result = await dispatcher.DispatchAsync<RemoveInventoryCommand, RemoveInventoryCommandResult>(
                command,
                cancellationToken
            );

            var transactionCommand = new AddInventoryTransactionCommand(
                result.InventoryId,
                MovementType.Out,
                command.Quantity,
                DateTime.Now,
                TransactionReason.Barter
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