using Domain.DTOs.BookReviewDTOs;
using Domain.DTOs.Response;

namespace Domain.Services.BookReviewService;

public interface IBookReviewService
{
    Task<Response<BookReview>> AddBookReview(BookReview bookReview, CancellationToken cancellationToken = default);
    Task<Response<BookReview>> UpdateBookReview(Guid bookReviewId,
        UpdateBookReviewequest bookReview, CancellationToken cancellationToken = default);
    Task<bool> DeleteBookReview(Guid bookReviewId, CancellationToken cancellationToken = default);
    Task<List<Response<BookReview>>> GetAllBookReviewByBookIdForUser( Guid bookId);
}