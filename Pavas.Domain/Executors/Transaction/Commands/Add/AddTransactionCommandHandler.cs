using Pavas.Abstractions.Dispatch.Commands.Contracts;

namespace Pavas.Domain.Executors.Transaction.Commands.Add;

public class AddTransactionCommandHandler : ICommandHandler<AddTransactionCommand>
{
    public Task HandleAsync(AddTransactionCommand command, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}