using Pavas.Abstractions.DatabaseContext.Contracts;
using Pavas.Abstractions.Dispatch.Commands.Contracts;
using Pavas.Abstractions.Exceptions;

namespace Pavas.Domain.Executors.Inventory.Commands.Subtract;

public class SubtractInventoryCommandHandler(
    IRepository repository
) : ICommandHandler<SubtractInventoryCommand, SubtractInventoryCommandResult>
{
    public async Task<SubtractInventoryCommandResult> HandleAsync(
        SubtractInventoryCommand command,
        CancellationToken cancellationToken = default
    )
    {
        var inventory = await repository.GetByIdAsync<Inventory, int>(command.InventoryId, cancellationToken);
        if (inventory is null)
        {
            throw new EntityNotFoundException($"Inventory With Id '{command.InventoryId}' Is Not Found");
        }

        if (inventory.Quantity < command.Quantity)
        {
            throw new NotAllowedException($"The Quantities Are Not Enough, Inventory {inventory.Quantity}");
        }

        inventory.Quantity -= command.Quantity;
        await repository.UpdateAsync(inventory, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
        return new SubtractInventoryCommandResult(inventory.Id);
    }
}