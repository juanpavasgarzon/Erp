using Pavas.Abstractions.Dispatch.Commands.Contracts;
using Pavas.Domain.Executors.Company.Commands.Inactivate;

namespace Pavas.Application.Executors.Company.Commands.Inactivate;

public class AppInactivateCompanyCommandHandler(
    ICommandDispatcher dispatcher
) : ICommandHandler<AppInactivateCompanyCommand>
{
    public async Task HandleAsync(AppInactivateCompanyCommand appCommand, CancellationToken cancellationToken = default)
    {
        var command = new InactivateCompanyCommand(appCommand.Id);
        await dispatcher.DispatchAsync(command, cancellationToken);
    }
}