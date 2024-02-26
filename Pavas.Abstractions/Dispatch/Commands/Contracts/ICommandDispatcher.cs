namespace Pavas.Abstractions.Dispatch.Commands.Contracts;

public interface ICommandDispatcher
{
    Task DispatchAsync<TCommand>(
        TCommand command,
        CancellationToken cancellationToken = default
    ) where TCommand : class, ICommand;

    Task<TResult> DispatchAsync<TCommand, TResult>(
        TCommand command,
        CancellationToken cancellationToken = default
    ) where TCommand : class, ICommand where TResult : class;
}