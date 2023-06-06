using Domain.Shared.Exceptions;
using Infrastructure.DBContext;

namespace Infrastructure.Shared;

public sealed class UnitOfWork : IUnitOfWork
{
    private readonly LibraryDbContext _libraryDbContext;

    public UnitOfWork(LibraryDbContext libraryDbContext)
    {
        _libraryDbContext = libraryDbContext;
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _libraryDbContext.SaveChangesAsync(cancellationToken);
    }
}
