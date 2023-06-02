using Domain.Repositories.SharedRepositories;
using Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.SharedRepositories;

public sealed class SharedRepository : ISharedRepository
{
    private readonly LibraryDBContext _libraryDbContext;

    public SharedRepository(LibraryDBContext libraryDbContext)
    {
        _libraryDbContext = libraryDbContext;
    }


    public async Task<bool> UserIsExistByUsername(string username)
    {
        return await _libraryDbContext.Users
       .AsNoTracking()
       .AnyAsync(x => x.Username == username);
    }

    public async Task<bool> UserIsExistsByEmail(string email)
    {
        return await _libraryDbContext.Users
            .AsNoTracking()
            .AnyAsync(x => x.Email == email);
    }
}
