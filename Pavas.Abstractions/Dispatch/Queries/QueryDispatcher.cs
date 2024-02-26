using Microsoft.Extensions.DependencyInjection;
using Pavas.Abstractions.Dispatch.Queries.Contracts;
using Pavas.Abstractions.Exceptions;

namespace Pavas.Abstractions.Dispatch.Queries;

public class QueryDispatcher(IServiceProvider serviceProvider) : IQueryDispatcher
{
    public async Task<TResult> QueryAsync<TResult>(
        CancellationToken cancellationToken = default
    ) where TResult : class
    {
        var service = serviceProvider.GetService<IQueryHandler<TResult>>();
        if (service == null)
        {
            throw new NullHandlerException("No handler found for " + typeof(IQueryHandler<TResult>).FullName);
        }

        return await service.HandleAsync(cancellationToken);
    }

    public async Task<TResult> QueryAsync<TQuery, TResult>(
        TQuery query,
        CancellationToken cancellationToken = default
    ) where TQuery : class, IQuery where TResult : class
    {
        var service = serviceProvider.GetService<IQueryHandler<TQuery, TResult>>();
        if (service == null)
        {
            throw new NullHandlerException("No handler found for " + typeof(IQueryHandler<TQuery, TResult>).FullName);
        }

        return await service.HandleAsync(query, cancellationToken);
    }
}