using Microsoft.EntityFrameworkCore.Storage;

namespace cw6.Repositories;

public interface IUnitOfWork : IAsyncDisposable
{
    Task BeginTransactionAsync(CancellationToken cancellationToken);
    Task CommitTransactionAsync(CancellationToken cancellationToken);
    Task RollbackTransactionAsync(CancellationToken cancellationToken);
}

public class UnitOfWork(Context.Context context) : IUnitOfWork
{
    private readonly Context.Context _context = context;
    private IDbContextTransaction _transaction = null!;
    private bool _disposed;

    public async Task BeginTransactionAsync(CancellationToken cancellationToken)
    {
        _transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
    }

    public async Task CommitTransactionAsync(CancellationToken cancellationToken)
    {
        await _transaction.CommitAsync(cancellationToken);
    }

    public async Task RollbackTransactionAsync(CancellationToken cancellationToken)
    {
        await _transaction.RollbackAsync(cancellationToken);
    }

    public async ValueTask DisposeAsync()
    {
        if (_disposed == false)
        {
            await _transaction.DisposeAsync();
            await _context.DisposeAsync();
            _disposed = true; 
        }

        GC.SuppressFinalize(this);
    }
}