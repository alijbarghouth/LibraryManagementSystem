using Domain.DTOs.BookReviewDTOs;
using Domain.Services.BookReviewService;

namespace Application.Handler.BookReviewHandler.AverageRatingForEachBookHandler;

public class AverageRatingForEachBookQueryHandler : IAverageRatingForEachBookQueryHandler
{
    private readonly IBookReviewService _bookReviewService;

    public AverageRatingForEachBookQueryHandler
        (IBookReviewService bookReviewService)
    {
        _bookReviewService = bookReviewService;
    }

    public async Task<List<BookRating>> Handel()
    {
        return await _bookReviewService.AverageRatingForEachBook();
    }
}