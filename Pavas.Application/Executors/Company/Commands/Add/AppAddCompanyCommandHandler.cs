using AutoMapper;
using Pavas.Abstractions.Dispatch.Commands.Contracts;
using Pavas.Domain.Executors.Company.Commands.Add;

namespace Pavas.Application.Executors.Company.Commands.Add;

public class AppAddCompanyCommandHandler(
    ICommandDispatcher dispatcher,
    IMapper mapper
) : ICommandHandler<AppAddCompanyCommand>
{
    public async Task HandleAsync(AppAddCompanyCommand appCommand, CancellationToken cancellationToken = default)
    {
        var command = mapper.Map<AddCompanyCommand>(appCommand);
        await dispatcher.DispatchAsync(command, cancellationToken);
    }
}