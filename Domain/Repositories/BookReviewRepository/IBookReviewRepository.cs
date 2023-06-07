using Domain.DTOs.BookReviewDTOs;
using Domain.DTOs.Response;

namespace Domain.Repositories.BookReviewRepository;

public interface IBookReviewRepository
{
    Task<Response<BookReview>> AddBookReview(BookReview bookReview);
    Task<Response<BookReview>> UpdateBookReview(Guid bookReviewId, UpdateBookReviewequest bookReview);
    Task<bool> DeleteBookReview(Guid bookReviewId);
    Task<List<Response<BookReview>>> GetAllBookReviewByBookIdForUser(Guid bookId);
}