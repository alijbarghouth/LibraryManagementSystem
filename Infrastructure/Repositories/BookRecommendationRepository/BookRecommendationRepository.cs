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

    public async Task<List<BookRecommendation>> GetBookRecommendations()
    {
        var allUsers = await _libraryDbContext.Users
            .Include(u => u.ReadingLists)
            .ThenInclude(rl => rl.Book)
            .ThenInclude(b => b.Genres)
            .Include(u => u.BookReviews)
            .ThenInclude(br => br.Book)
            .ThenInclude(b => b.Genres)
            .ToListAsync();

        var reservedBooks = await _libraryDbContext.OrderItems
            .GroupBy(oi => oi.BookId)
            .OrderByDescending(g => g.Count())
            .Select(g => g.Key)
            .ToListAsync();


        var readGenres = allUsers
            .SelectMany(u => u.BookReviews)
            .SelectMany(br => br.Book.Genres)
            .GroupBy(g => g.Id)
            .OrderByDescending(g => g.Count())
            .Select(g => g.First())
            .ToList();

        var recommendedBooks = await _libraryDbContext.Books
            .Include(b => b.BookReviews)
            .Include(x => x.Genres)
            .Where(b => reservedBooks.Contains(b.Id) || b.Genres.Any(g => readGenres.Contains(g)))
            .ToListAsync();

        foreach (var book in recommendedBooks)
        {
            var averageRating = book.BookReviews.Any() ? book.BookReviews.Average(r => r.Rating) : 0;
            book.AverageRating = averageRating;
            await _libraryDbContext.SaveChangesAsync();
        }

        recommendedBooks = recommendedBooks.OrderByDescending(b => b.AverageRating).ToList();

        var topRatedBooks = recommendedBooks.Take(5);

        var bookRecommendations = topRatedBooks.Select(b => new BookRecommendation
        (
            b.Title,
            b.AverageRating,
            b.Genres.ToList().Adapt<List<Domain.DTOs.GenreDTOs.Genre>>(),
            b.Authors.ToList().Adapt<List<Domain.DTOs.AuthorDTOs.Author>>()
        )).ToList();

        return bookRecommendations;
    }

    public async Task<List<BookRecommendation>> GetPersonalizedBookRecommendations(Guid patronId)
    {
        // Retrieve the patron's borrowing history
        var borrowingHistory = await _libraryDbContext.Orders
            .Where(o => o.UserId == patronId && o.StatusRequest == StatusRequest.CheckedOut)
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.Book)
            .ToListAsync();

        // Aggregate the genres from the borrowing history
        var genres = borrowingHistory
            .SelectMany(order => order.OrderItems.Select(oi => oi.Book.Genres))
            .Distinct()
            .ToList();

        // Retrieve recommended books based on genres
        var recommendedBooks = await _libraryDbContext.Books
            .Where(book => genres.Contains(book.Genres))
            .ToListAsync();

        return recommendedBooks.Adapt<List<BookRecommendation>>();
    }
}