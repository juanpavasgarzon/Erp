using AutoMapper;
using Pavas.Abstractions.Dispatch.Commands.Contracts;
using Pavas.Domain.Executors.Customer.Commands.Add;

namespace Pavas.Application.Executors.Customer.Commands.Add;

public class AppAddCustomerCommandHandler(
    ICommandDispatcher dispatcher,
    IMapper mapper
) : ICommandHandler<AppAddCustomerCommand>
{
    public async Task HandleAsync(AppAddCustomerCommand appCommand, CancellationToken cancellationToken = default)
    {
        var command = mapper.Map<AddCustomerCommand>(appCommand);
        await dispatcher.DispatchAsync(command, cancellationToken);
    }
}