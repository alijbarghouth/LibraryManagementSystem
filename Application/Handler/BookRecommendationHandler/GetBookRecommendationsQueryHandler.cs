using Application.Cashing;
using Application.Query.BookQuery;
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

    public async Task<List<BookRecommendation>> Handel(GetBookRecommendationsQuery query)
    {
        return await _bookRecommendationService.GetBookRecommendations(query.UserId);
    }
}