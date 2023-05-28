using Domain.Features.UserService.SharedRepositories;
using Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Features.UserFeature.SharedRepositories;

public sealed class SharedRepository : ISharedRepository
{
    private readonly LibraryDBContext _libraryDBContext;

    public SharedRepository(LibraryDBContext libraryDBContext)
    {
        _libraryDBContext = libraryDBContext;
    }


    public async Task<bool> UserIsExistByUsername(string username)
    {
        return await _libraryDBContext.Users
       .AsNoTracking()
       .AnyAsync(x => x.Username == username);
    }

    public async Task<bool> UserIsExistsByEmail(string email)
    {
        return await _libraryDBContext.Users
            .AsNoTracking()
            .AnyAsync(x => x.Email == email);
    }
}
