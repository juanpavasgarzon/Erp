using AutoMapper;
using Pavas.Abstractions.Dispatch.Commands.Contracts;
using Pavas.Domain.Executors.Employee.Commands.Add;

namespace Pavas.Application.Executors.Employee.Commands;

public class AppAddEmployeeCommandHandler(
    ICommandDispatcher dispatcher,
    IMapper mapper
) : ICommandHandler<AppAddEmployeeCommand>
{
    public async Task HandleAsync(AppAddEmployeeCommand appCommand, CancellationToken cancellationToken = default)
    {
        var command = mapper.Map<AddEmployeeCommand>(appCommand);
        await dispatcher.DispatchAsync(command, cancellationToken);
    }
}