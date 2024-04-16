using Pavas.Abstractions.Dispatch.Commands.Contracts;
using Pavas.Domain.Executors.Employee.Commands.Add;

namespace Pavas.Application.Executors.Employee.Commands;

public class AppAddEmployeeCommandHandler(ICommandDispatcher dispatcher) : ICommandHandler<AppAddEmployeeCommand>
{
    public async Task HandleAsync(AppAddEmployeeCommand appCommand, CancellationToken cancellationToken = default)
    {
        var command = new AddEmployeeCommand(
            appCommand.Id,
            appCommand.FirstName,
            appCommand.LastName,
            appCommand.Email,
            appCommand.PhoneNumber,
            appCommand.CompanyId,
            appCommand.HireDate
        );
        await dispatcher.DispatchAsync(command, cancellationToken);
    }
}