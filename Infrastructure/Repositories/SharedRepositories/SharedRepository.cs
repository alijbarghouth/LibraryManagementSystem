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

    public async Task<bool> UserIsExistsUserId(Guid userId)
    {
        return await _libraryDbContext.Users
            .AsNoTracking()
            .AnyAsync(x => x.Id == userId);
    }

    public async Task<bool> OrderIsExistsByOrderId(Guid orderId)
    {
        return await _libraryDbContext.Orders
            .AsNoTracking()
            .AnyAsync(x => x.Id == orderId);
    }

    public async Task<bool> IsBookExistsByTitle(string bookTitle)
    {
        return await _libraryDbContext.Books
            .AsNoTracking()
            .AnyAsync(x => x.Title == bookTitle);
    }

    public async Task<bool> IsBookExistsByBookId(Guid bookId)
    {
        return await _libraryDbContext.Books
            .AsNoTracking()
            .AnyAsync(x => x.Id == bookId);
    }

    public async Task<bool> IsBookGenreExists(string bookGenre)
    {
        return await _libraryDbContext.Genres
            .AsNoTracking()
            .AnyAsync(x => x.Name == bookGenre);
    }

    public async Task<bool> IsBookGenreExistsById(Guid genreId)
    {
        return await _libraryDbContext.Genres
            .AsNoTracking()
            .AnyAsync(x => x.Id == genreId);
    }
}
