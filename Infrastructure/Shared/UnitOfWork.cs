using Domain.Shared.Exceptions;
using Infrastructure.DBContext;

namespace Infrastructure.Shared;

public sealed class UnitOfWork : IUnitOfWork
{
    private readonly LibraryDbContext _libraryDBContext;

    public UnitOfWork(LibraryDbContext libraryDBContext)
    {
        _libraryDBContext = libraryDBContext;
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _libraryDBContext.SaveChangesAsync(cancellationToken);
    }
}
