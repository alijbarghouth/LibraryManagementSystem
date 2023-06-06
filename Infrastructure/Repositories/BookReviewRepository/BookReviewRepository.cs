using Domain.DTOs.Response;
using Domain.Repositories.BookReviewRepository;
using Infrastructure.DBContext;
using Infrastructure.Model;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.BookReviewRepository;

public sealed class BookReviewRepository : IBookReviewRepository
{
    private readonly LibraryDbContext _libraryDbContext;

    public BookReviewRepository(LibraryDbContext libraryDbContext)
    {
        _libraryDbContext = libraryDbContext;
    }

    public async Task<Response<Domain.DTOs.BookReviewDTOs.BookReview>> AddBookReview(
        Domain.DTOs.BookReviewDTOs.BookReview bookReview)
    {
        var review = bookReview.Adapt<BookReview>();
        await _libraryDbContext.BookReviews.AddAsync(review);
        return new Response<Domain.DTOs.BookReviewDTOs.BookReview>(bookReview, review.Id);
    }

    public async Task<Response<Domain.DTOs.BookReviewDTOs.BookReview>> UpdateBookReview(Guid bookReviewId,
        Domain.DTOs.BookReviewDTOs.UpdateBookReviewequest bookReview)
    {
        var oldBookReview = await _libraryDbContext.BookReviews
            .SingleAsync(x => x.Id == bookReviewId);
        var newBookReview = bookReview.Adapt(oldBookReview);
        var updatedBookReview = newBookReview.Adapt<Domain.DTOs.BookReviewDTOs.BookReview>();
        _libraryDbContext.BookReviews.Update(newBookReview);
        return new Response<Domain.DTOs.BookReviewDTOs.BookReview>(updatedBookReview, newBookReview.Id);
    }

    public async Task<bool> DeleteBookReview(Guid bookReviewId)
    {
        var bookReview = await _libraryDbContext.BookReviews
            .SingleAsync(x => x.Id == bookReviewId);
        _libraryDbContext.BookReviews
            .Remove(bookReview);
        return true;
    }

    public async Task<List<Response<Domain.DTOs.BookReviewDTOs.BookReview>>> GetAllBookReviewByBookIdAndUserId(
        Guid userId, Guid bookId)
    {
        return await _libraryDbContext.BookReviews
            .Where(x => x.UserId == userId && x.BookId == bookId
                 && x.Moderations.All(i => i.IsApproved))
            .Select(x
                => new Response<Domain.DTOs.BookReviewDTOs.BookReview>
                    (x.Adapt<Domain.DTOs.BookReviewDTOs.BookReview>(), x.Id))
            .ToListAsync();
    }
}