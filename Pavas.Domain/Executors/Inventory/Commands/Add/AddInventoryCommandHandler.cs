using Pavas.Abstractions.DatabaseContext.Contracts;
using Pavas.Abstractions.Dispatch.Commands.Contracts;

namespace Pavas.Domain.Executors.Inventory.Commands.Add;

public class AddInventoryCommandHandler(
    IRepository repository
) : ICommandHandler<AddInventoryCommand, AddInventoryCommandResult>
{
    public async Task<AddInventoryCommandResult> HandleAsync(
        AddInventoryCommand command,
        CancellationToken cancellationToken = default
    )
    {
        var inventory = await repository.GetFirstByIdAsync<Inventory>(
            i => i.Code == command.Code,
            cancellationToken
        );

        if (inventory is null)
        {
            inventory = new Inventory(
                command.Code,
                command.Name,
                command.Description,
                command.CompanyId,
                command.Type,
                command.Price,
                command.Quantity
            );

            inventory = await repository.AddAsync(inventory, cancellationToken);
        }
        else
        {
            inventory.Quantity += command.Quantity;
            await repository.UpdateAsync(inventory, cancellationToken);
        }

        await repository.SaveChangesAsync(cancellationToken);

        return new AddInventoryCommandResult(inventory.Id);
    }
}