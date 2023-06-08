using Domain.Repositories.SharedRepositories;
using Domain.Shared.Exceptions.CustomException;
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


    public async Task<bool> IsUserExistByUsername(string username)
    {
        return await _libraryDbContext.Users
            .AsNoTracking()
            .AnyAsync(x => x.Username == username);
    }

    public async Task<bool> IsUserExistsByEmail(string email)
    {
        return await _libraryDbContext.Users
            .AsNoTracking()
            .AnyAsync(x => x.Email == email);
    }

    public async Task<bool> IsUserExistsUserId(Guid userId)
    {
        return await _libraryDbContext.Users
            .AsNoTracking()
            .AnyAsync(x => x.Id == userId);
    }

    public async Task<(string, string)> FindUserEmailAndUsernameById(Guid userId)
    {
        var user = await _libraryDbContext.Users
            .FindAsync(userId);
        if (user is null)
            throw new NotFoundException("user not found");
        return (user.Username, user.Email);
    }
}