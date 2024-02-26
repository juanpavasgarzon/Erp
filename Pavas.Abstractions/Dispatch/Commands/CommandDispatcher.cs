using Microsoft.Extensions.DependencyInjection;
using Pavas.Abstractions.Dispatch.Commands.Contracts;
using Pavas.Abstractions.Exceptions;

namespace Pavas.Abstractions.Dispatch.Commands;

public class CommandDispatcher(IServiceProvider serviceProvider) : ICommandDispatcher
{
    public async Task DispatchAsync<TCommand>(
        TCommand command,
        CancellationToken cancellationToken = default
    ) where TCommand : class, ICommand
    {
        var service = serviceProvider.GetService<ICommandHandler<TCommand>>();
        if (service == null)
        {
            var fullName = typeof(ICommandHandler<TCommand>).FullName;

            throw new NullHandlerException("No handler found for " + fullName);
        }

        await service.HandleAsync(command, cancellationToken);
    }

    public async Task<TResult> DispatchAsync<TCommand, TResult>(
        TCommand command,
        CancellationToken cancellationToken = default
    ) where TCommand : class, ICommand where TResult : class
    {
        var service = serviceProvider.GetService<ICommandHandler<TCommand, TResult>>();
        if (service == null)
        {
            var fullName = typeof(ICommandHandler<TCommand, TResult>).FullName;

            throw new NullHandlerException("No handler found for " + fullName);
        }

        return await service.HandleAsync(command, cancellationToken);
    }
}