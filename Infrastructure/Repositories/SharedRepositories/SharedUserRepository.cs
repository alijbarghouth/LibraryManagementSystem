using Domain.Repositories.SharedRepositories;
using Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.SharedRepositories;

public sealed class SharedUserRepository : ISharedUserRepository
{
    private readonly LibraryDbContext _libraryDbContext;

    public SharedUserRepository(LibraryDbContext libraryDbContext)
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

    public async Task<bool> UserIsExistsUserId(Guid userId)
    {
        return await _libraryDbContext.Users
            .AsNoTracking()
            .AnyAsync(x => x.Id == userId);
    }

   
}
