using Domain.DTOs.BookReviewDTOs;

namespace Application.Handler.BookReviewHandler.AverageRatingForEachBookHandler;

public interface IAverageRatingForEachBookQueryHandler
{
    Task<List<BookRating>> Handel();
}