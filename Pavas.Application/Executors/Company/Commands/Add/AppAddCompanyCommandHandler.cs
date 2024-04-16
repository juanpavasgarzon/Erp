using Pavas.Abstractions.Dispatch.Commands.Contracts;
using Pavas.Domain.Executors.Company.Commands.Add;

namespace Pavas.Application.Executors.Company.Commands.Add;

public class AppAddCompanyCommandHandler(ICommandDispatcher dispatcher) : ICommandHandler<AppAddCompanyCommand>
{
    public async Task HandleAsync(AppAddCompanyCommand appCommand, CancellationToken cancellationToken = default)
    {
        var command = new AddCompanyCommand(
            appCommand.Id,
            appCommand.Name,
            appCommand.Industry,
            appCommand.Email,
            appCommand.FoundedDate
        );
        await dispatcher.DispatchAsync(command, cancellationToken);
    }
}