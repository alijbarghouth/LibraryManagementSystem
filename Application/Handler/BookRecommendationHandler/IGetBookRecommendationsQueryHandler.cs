using Application.Query.BookQuery;
using Domain.DTOs.BookRecommendationDTOs;

namespace Application.Handler.BookRecommendationHandler;

public interface IGetBookRecommendationsQueryHandler
{
    Task<List<BookRecommendation>> Handel(GetBookRecommendationsQuery query);
}