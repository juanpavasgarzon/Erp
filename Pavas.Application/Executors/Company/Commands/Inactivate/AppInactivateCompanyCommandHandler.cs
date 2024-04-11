using AutoMapper;
using Pavas.Abstractions.Dispatch.Commands.Contracts;
using Pavas.Domain.Executors.Company.Commands.Inactivate;

namespace Pavas.Application.Executors.Company.Commands.Inactivate;

public class AppInactivateCompanyCommandHandler(
    ICommandDispatcher dispatcher,
    IMapper mapper
) : ICommandHandler<AppInactivateCompanyCommand>
{
    public async Task HandleAsync(AppInactivateCompanyCommand appCommand, CancellationToken cancellationToken = default)
    {
        var command = mapper.Map<InactivateCompanyCommand>(appCommand);
        await dispatcher.DispatchAsync(command, cancellationToken);
    }
}