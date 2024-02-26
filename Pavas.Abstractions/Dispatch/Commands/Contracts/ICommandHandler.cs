namespace Pavas.Abstractions.Dispatch.Commands.Contracts;

public interface ICommandHandler<in TCommand> where TCommand : class, ICommand
{
    Task HandleAsync(TCommand command, CancellationToken cancellationToken = default);
}

public interface ICommandHandler<in TCommand, TResult> where TCommand : class, ICommand where TResult : class
{
    Task<TResult> HandleAsync(TCommand command, CancellationToken cancellationToken = default);
}