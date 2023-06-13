using Domain.DTOs.BookRecommendationDTOs;
using Domain.Services.BookRecommendationService;

namespace Application.Handler.BookRecommendationHandler;

public class GetBookRecommendationsQueryHandler : IGetBookRecommendationsQueryHandler
{
    private readonly IBookRecommendationService _bookRecommendationService;

    public GetBookRecommendationsQueryHandler
        (IBookRecommendationService bookRecommendationService)
    {
        _bookRecommendationService = bookRecommendationService;
    }

    public async Task<List<BookRecommendation>> Handel()
    {
        return await _bookRecommendationService.GetBookRecommendations();
    }
}