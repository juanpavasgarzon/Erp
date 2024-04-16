using AutoMapper;
using Pavas.Abstractions.DatabaseContext.Contracts;
using Pavas.Abstractions.Dispatch.Commands.Contracts;
using Pavas.Application.Executors.Inventory.Commands.Subtract;
using Pavas.Domain.Executors.Inventory.Commands.Remove;
using Pavas.Domain.Executors.Inventory.Commands.Transaction;
using Pavas.Domain.Executors.Inventory.Constants;

namespace Pavas.Application.Executors.Inventory.Commands.Remove;

public class AppSubtractInventoryCommandHandler(
    ICommandDispatcher dispatcher,
    IMapper mapper,
    IRepository repository
) : ICommandHandler<AppSubtractInventoryCommand>
{
    public async Task HandleAsync(AppSubtractInventoryCommand appCommand, CancellationToken cancellationToken = default)
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