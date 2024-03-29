using Domain.DTOs.BookRecommendationDTOs;
using Domain.Repositories.BookRecommendationRepository;
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
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.Book)
            .ThenInclude(x => x.Genres)
            .Where(o => o.UserId == patronId)
            .ToListAsync();

        var borrowingBookIds = borrowingHistory
            .SelectMany(order => order.OrderItems.Select(oi => oi.BookId))
            .Distinct()
            .ToList();

        var genres = borrowingHistory
            .SelectMany(order => order.OrderItems.SelectMany(oi => oi.Book.Genres))
            .Distinct()
            .ToList();

        var recommendedBooks =  _libraryDbContext.Books
            .Include(x => x.Authors)
            .Include(x => x.Genres)
            .Where(book => genres.Any(bg => book.Genres.Any(x => x.Name == bg.Name)))
            .Where(book => !borrowingBookIds.Contains(book.Id))
            .Select(x => new
            {
                BookTitle = x.Title,
                Genres = x.Genres.ToList(),
                Authors = x.Authors.ToList()
            })
            .ToList();

        return recommendedBooks.Adapt<List<BookRecommendation>>();
    }
}