using Domain.DTOs.BookRecommendationDTOs;

namespace Domain.Repositories.BookRecommendationRepository;

public interface IBookRecommendationRepository
{
    Task<List<BookRecommendation>> GetBookRecommendations();
    Task<List<BookRecommendation>> GetPersonalizedBookRecommendations(Guid patronId);
}