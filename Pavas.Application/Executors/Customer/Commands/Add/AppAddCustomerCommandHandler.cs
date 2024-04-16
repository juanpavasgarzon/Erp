using Pavas.Abstractions.Dispatch.Commands.Contracts;
using Pavas.Domain.Executors.Customer.Commands.Add;

namespace Pavas.Application.Executors.Customer.Commands.Add;

public class AppAddCustomerCommandHandler(ICommandDispatcher dispatcher) : ICommandHandler<AppAddCustomerCommand>
{
    public async Task HandleAsync(AppAddCustomerCommand appCommand, CancellationToken cancellationToken = default)
    {
        var command = new AddCustomerCommand(
            appCommand.Id,
            appCommand.FirstName,
            appCommand.LastName,
            appCommand.Email,
            appCommand.PhoneNumber
        );
        await dispatcher.DispatchAsync(command, cancellationToken);
    }
}