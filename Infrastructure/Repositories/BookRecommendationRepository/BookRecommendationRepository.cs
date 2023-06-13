using Domain.DTOs.BookRecommendationDTOs;
using Domain.Repositories.BookRecommendationRepository;
using Domain.Shared.Enums;
using Infrastructure.DBContext;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.BookRecommendationRepository;

public class BookRecommendationRepository : IBookRecommendationRepository
{
    private readonly LibraryDbContext _libraryDbContext;

    public BookRecommendationRepository(LibraryDbContext libraryDbContext)
    {
        _libraryDbContext = libraryDbContext;
    }

    public async Task<List<BookRecommendation>> GetPersonalizedBookRecommendations(Guid patronId)
    {
        var borrowingHistory = await _libraryDbContext.Orders
            .Where(o => o.UserId == patronId && o.StatusRequest == StatusRequest.CheckedOut)
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.Book)
            .ToListAsync();

        var genres = borrowingHistory
            .SelectMany(order => order.OrderItems.Select(oi => oi.Book.Genres))
            .Distinct()
            .ToList();

        var recommendedBooks = await _libraryDbContext.Books
            .Where(book => genres.Contains(book.Genres))
            .ToListAsync();

        return recommendedBooks.Adapt<List<BookRecommendation>>();
    }
}