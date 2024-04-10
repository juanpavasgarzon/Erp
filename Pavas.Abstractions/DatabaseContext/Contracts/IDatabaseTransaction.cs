namespace Pavas.Abstractions.DatabaseContext.Contracts;

public interface IDatabaseTransaction: IAsyncDisposable
{
    Task CommitAsync();
    
    Task RollbackAsync();
}