using Domain.Shared.Exceptions;
using Infrastructure.DBContext;

namespace Infrastructure.Shared;

public sealed class UnitOfWork : IUnitOfWork
{
    private readonly LibraryDBContext _libraryDBContext;

    public UnitOfWork(LibraryDBContext libraryDBContext)
    {
        _libraryDBContext = libraryDBContext;
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _libraryDBContext.SaveChangesAsync(cancellationToken);
    }
}
