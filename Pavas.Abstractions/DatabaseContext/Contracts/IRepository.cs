using System.Linq.Expressions;

namespace Pavas.Abstractions.DatabaseContext.Contracts;

public interface IRepository
{
    Task<TEntity> AddAsync<TEntity>(
        TEntity entity,
        CancellationToken cancellationToken = default
    ) where TEntity : class;

    Task AddRangeAsync<TEntity>(
        IEnumerable<TEntity> entities,
        CancellationToken cancellationToken = default
    ) where TEntity : class;

    Task UpdateAsync<TEntity>(
        TEntity entity,
        CancellationToken cancellationToken = default
    ) where TEntity : class;

    Task DeleteAsync<TEntity>(
        TEntity entity,
        CancellationToken cancellationToken = default
    ) where TEntity : class;

    Task<TEntity?> GetByIdAsync<TEntity, TKey>(
        TKey key,
        CancellationToken cancellationToken = default
    ) where TEntity : class;

    Task<IQueryable<TEntity>> GetAllAsync<TEntity>(
        CancellationToken cancellationToken = default
    ) where TEntity : class;

    Task<IQueryable<TEntity>> GetByAsync<TEntity>(
        Expression<Func<TEntity, bool>> predicate,
        CancellationToken cancellationToken = default
    ) where TEntity : class;

    Task<int> SaveChangesAsync(
        CancellationToken cancellationToken = default
    );

    Task<IDatabaseTransaction> BeginTransactionAsync(
        CancellationToken cancellationToken = default
    );
}