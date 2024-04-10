using Pavas.Abstractions.Dispatch.Commands.Contracts;

namespace Pavas.Domain.Executors.Inventory.Commands.Add;

public class AddInventoryCommandHandler : ICommandHandler<AddInventoryCommand>
{
    public Task HandleAsync(AddInventoryCommand command, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}