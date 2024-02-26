using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Pavas.Abstractions.DatabaseContext.Contracts;

namespace Pavas.Abstractions.DatabaseContext;

public class Repository : IRepository
{
    private readonly BaseContext _context;

    public Repository(BaseContext context)
    {
        _context = context;
        _context.Database.EnsureCreated();
    }

    public async Task<TEntity> AddAsync<TEntity>(
        TEntity entity,
        CancellationToken cancellationToken = default
    ) where TEntity : class
    {
        await _context.Set<TEntity>().AddAsync(entity, cancellationToken);

        return entity;
    }

    public async Task AddRangeAsync<TEntity>(
        IEnumerable<TEntity> entities,
        CancellationToken cancellationToken = default
    ) where TEntity : class
    {
        await _context.Set<TEntity>().AddRangeAsync(entities, cancellationToken);
    }

    public async Task UpdateAsync<TEntity>(
        TEntity entity,
        CancellationToken cancellationToken = default
    ) where TEntity : class
    {
        await Task.Run((Action)(() => _context.Set<TEntity>().Update(entity)), cancellationToken);
    }

    public async Task DeleteAsync<TEntity>(
        TEntity entity,
        CancellationToken cancellationToken = default
    ) where TEntity : class
    {
        await Task.Run((Action)(() => _context.Set<TEntity>().Remove(entity)), cancellationToken);
    }

    public async Task<TEntity?> GetByIdAsync<TEntity, TKey>(
        TKey key,
        CancellationToken cancellationToken = default
    ) where TEntity : class
    {
        if (key == null)
        {
            throw new ArgumentNullException(nameof(key));
        }

        return await _context.Set<TEntity>().FindAsync([(TKey)key], cancellationToken);
    }

    public async Task<IQueryable<TEntity>> GetAllAsync<TEntity>(
        CancellationToken cancellationToken = default
    ) where TEntity : class
    {
        var task = new Task<IQueryable<TEntity>>(
            () => _context.Set<TEntity>().AsNoTracking().AsQueryable(),
            cancellationToken
        );

        task.Start();

        return await task;
    }

    public async Task<IQueryable<TEntity>> GetByAsync<TEntity>(
        Expression<Func<TEntity, bool>> predicate,
        CancellationToken cancellationToken = default
    ) where TEntity : class
    {
        var task = new Task<IQueryable<TEntity>>(
            () => _context.Set<TEntity>().Where(predicate).AsNoTracking().AsQueryable(),
            cancellationToken
        );

        task.Start();

        return await task;
    }

    public async Task<int> SaveChangesAsync(
        CancellationToken cancellationToken = default
    )
    {
        return await _context.SaveChangesAsync(
            cancellationToken
        );
    }

    public Task<ITransaction> BeginTransactionAsync(
        CancellationToken cancellationToken = default
    )
    {
        return Task.FromResult<ITransaction>(
            new Transaction(_context, cancellationToken)
        );
    }
}