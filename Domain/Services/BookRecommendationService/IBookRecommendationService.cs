using Domain.DTOs.BookRecommendationDTOs;

namespace Domain.Services.BookRecommendationService;

public interface IBookRecommendationService
{
    Task<List<BookRecommendation>> GetBookRecommendations(Guid userId);
}