using Domain.DTOs.BookRecommendationDTOs;
using Domain.Repositories.BookRecommendationRepository;

namespace Domain.Services.BookRecommendationService;

public class BookRecommendationService : IBookRecommendationService
{
    private readonly IBookRecommendationRepository _bookRecommendationRepository;

    public BookRecommendationService(IBookRecommendationRepository bookRecommendationRepository)
    {
        _bookRecommendationRepository = bookRecommendationRepository;
    }

    public async Task<List<BookRecommendation>> GetBookRecommendations()
    {
        return await _bookRecommendationRepository.GetBookRecommendations();
    }
}