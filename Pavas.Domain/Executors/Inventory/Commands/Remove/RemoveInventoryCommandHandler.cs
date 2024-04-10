using Pavas.Abstractions.Dispatch.Commands.Contracts;

namespace Pavas.Domain.Executors.Inventory.Commands.Remove;

public class RemoveInventoryCommandHandler : ICommandHandler<RemoveInventoryCommand>
{
    public Task HandleAsync(RemoveInventoryCommand command, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}