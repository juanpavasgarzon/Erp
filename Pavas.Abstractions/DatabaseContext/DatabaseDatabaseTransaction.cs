using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Pavas.Abstractions.DatabaseContext.Contracts;

namespace Pavas.Abstractions.DatabaseContext;

public class DatabaseDatabaseTransaction : IDatabaseTransaction
{
    private readonly IDbContextTransaction _transaction;
    private readonly CancellationToken _cancellationToken;

    public DatabaseDatabaseTransaction(DbContext context, CancellationToken cancellationToken = default)
    {
        _transaction = context.Database.BeginTransactionAsync(cancellationToken).Result;
        _cancellationToken = cancellationToken;
    }

    public async ValueTask DisposeAsync()
    {
        await _transaction.DisposeAsync();
    }

    public async Task CommitAsync()
    {
        await _transaction.CommitAsync(_cancellationToken);
    }

    public async Task RollbackAsync()
    {
        await _transaction.RollbackAsync(_cancellationToken);
    }
}