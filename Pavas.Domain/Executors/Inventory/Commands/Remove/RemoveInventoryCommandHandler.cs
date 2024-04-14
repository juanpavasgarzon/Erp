using Pavas.Abstractions.DatabaseContext.Contracts;
using Pavas.Abstractions.Dispatch.Commands.Contracts;
using Pavas.Abstractions.Exceptions;

namespace Pavas.Domain.Executors.Inventory.Commands.Remove;

public class RemoveInventoryCommandHandler(
    IRepository repository
) : ICommandHandler<RemoveInventoryCommand, RemoveInventoryCommandResult>
{
    public async Task<RemoveInventoryCommandResult> HandleAsync(
        RemoveInventoryCommand command,
        CancellationToken cancellationToken = default
    )
    {
        var inventory = await repository.GetFirstByIdAsync<Inventory>(
            i => i.Code == command.Code,
            cancellationToken
        );

        if (inventory is null)
        {
            throw new EntityNotFoundException($"Inventory With Code {command.Code} Is not Allowed");
        }

        if (inventory.Quantity < command.Quantity)
        {
            throw new NotAllowedException($"The Quantities Are Not Enough, Inventory {inventory.Quantity}");
        }

        inventory.Quantity -= command.Quantity;
        await repository.UpdateAsync(inventory, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
        return new RemoveInventoryCommandResult(inventory.Id);
    }
}