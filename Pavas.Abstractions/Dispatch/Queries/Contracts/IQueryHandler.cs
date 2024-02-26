namespace Pavas.Abstractions.Dispatch.Queries.Contracts;

public interface IQueryHandler<TResult> where TResult : class
{
    Task<TResult> HandleAsync(CancellationToken cancellationToken = default);
}

public interface IQueryHandler<in TQuery, TResult> where TQuery : IQuery where TResult : class
{
    Task<TResult> HandleAsync(TQuery query, CancellationToken cancellationToken = default);
}