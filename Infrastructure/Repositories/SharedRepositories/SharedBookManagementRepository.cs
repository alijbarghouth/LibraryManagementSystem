using Domain.Repositories.SharedRepositories;
using Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.SharedRepositories;

public class SharedBookManagementRepository : ISharedBookManagementRepository
{
    private readonly LibraryDBContext _libraryDbContext;

    public SharedBookManagementRepository(LibraryDBContext libraryDbContext)
    {
        _libraryDbContext = libraryDbContext;
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

    public async Task<bool> IsGenreExistsByTitle(string bookGenre)
    {
        return await _libraryDbContext.Genres
            .AsNoTracking()
            .AnyAsync(x => x.Name == bookGenre);
    }

    public async Task<bool> IsGenreExistsById(Guid genreId)
    {
        return await _libraryDbContext.Genres
            .AsNoTracking()
            .AnyAsync(x => x.Id == genreId);
    }

    public async Task<bool> IsAuthorExistsByAuthorName(string authorName)
    {
        return await _libraryDbContext.Authors
            .AsNoTracking()
            .AnyAsync(x => x.Username == authorName);
    }

    public async Task<bool> IsAuthorExistsByAuthorId(Guid authorId)
    {
        return await _libraryDbContext.Authors
            .AsNoTracking()
            .AnyAsync(x => x.Id == authorId);
    }
}