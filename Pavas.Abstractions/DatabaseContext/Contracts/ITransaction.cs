namespace Pavas.Abstractions.DatabaseContext.Contracts;

public interface ITransaction: IAsyncDisposable
{
    Task CommitAsync();
    
    Task RollbackAsync();
}