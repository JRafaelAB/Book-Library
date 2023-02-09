using Domain.UnitOfWork;
using Infrastructure.DataAccess.Contexts;

namespace Infrastructure.DataAccess;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly LibraryContext _clockContext;
    private bool _disposed;

    public UnitOfWork(LibraryContext clockContext) => this._clockContext = clockContext;

    public void Dispose()
    {
        this.Dispose(true);
        GC.SuppressFinalize(this);
    }

    public async Task<int> Save()
    {
        int affectedRows = await this._clockContext
            .SaveChangesAsync();
        return affectedRows;
    }
        
    private void Dispose(bool disposing)
    {
        if (!this._disposed && disposing)
        {
            this._clockContext.Dispose();
        }

        this._disposed = true;
    }
}
