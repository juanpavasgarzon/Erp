namespace Pavas.Abstractions.Dispatch.Queries.Contracts;

public interface IQueryDispatcher
{
    Task<TResult> QueryAsync<TResult>(
        CancellationToken cancellationToken = default
    ) where TResult : class;

    Task<TResult> QueryAsync<TQuery, TResult>(
        TQuery query,
        CancellationToken cancellationToken = default
    ) where TQuery : class, IQuery where TResult : class;
}