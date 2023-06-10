using Domain.Repositories.SharedRepositories;
using Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.SharedRepositories;

public sealed class SharedBookManagementRepository : ISharedBookManagementRepository
{
    private readonly LibraryDbContext _libraryDbContext;

    public SharedBookManagementRepository(LibraryDbContext libraryDbContext)
    {
        _libraryDbContext = libraryDbContext;
    }

    public async Task<bool> IsOrderExistsByOrderId(Guid orderId)
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

    public async Task<bool> IsReadingListExistsByAuthorId(Guid readingListId)
    {
        return await _libraryDbContext.ReadingLists
            .AsNoTracking()
            .AnyAsync(x => x.Id == readingListId);
    }

    public async Task<bool> IsBookExistsInReadingList(Guid bookId)
    {
        return await _libraryDbContext.ReadingLists
            .AsNoTracking()
            .AnyAsync(x => x.BookId == bookId);
    }

    public async Task<bool> IsBookReviewExistsByBookReviewId(Guid bookReviewId)
    {
        return await _libraryDbContext.BookReviews
            .AsNoTracking()
            .AnyAsync(x => x.Id == bookReviewId);
    }

    public async Task<bool> IsInteractionExistsByInteractionId(Guid bookReviewId)
    {
        return await _libraryDbContext.Interactions
            .AsNoTracking()
            .AnyAsync(x => x.Id == bookReviewId);
    }

    public async Task<bool> IsInteractionExistsByBookReviewIdAndUserId(Guid userId, Guid bookReviewId)
    {
        return await _libraryDbContext.Interactions
            .AsNoTracking()
            .AnyAsync(x => x.UserId == userId && x.BookReviewId == bookReviewId);
    }

    public async Task<bool> IsReadingListExistsByBookIdAndUserId(Guid userId, Guid bookId)
    {
        return await _libraryDbContext.ReadingLists
            .AsNoTracking()
            .AnyAsync(x => x.UserId == userId && x.BookId == bookId);
    }
}