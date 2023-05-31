using Domain.DTOs.BookAuthorDTOs;
using Domain.DTOs.BookDTOs;
using Domain.Repositories.BookRepository;
using Infrastructure.DBContext;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.BookRepository;

public sealed class BookRepository : IBookRepository
{
    private readonly LibraryDBContext _libraryDBContext;

    public BookRepository(LibraryDBContext libraryDBContext)
    {
        _libraryDBContext = libraryDBContext;
    }
    public async Task<List<Book>> SearchBookByTitle(string bookTitle, PaginationFilter filter)
    {
        var query = await _libraryDBContext.Books
            .AsNoTracking()
            .Where(x => string.IsNullOrEmpty(bookTitle) || x.Title.Contains(bookTitle))
            .Select(x => new
            {
                x.Title,
                Author = x.Authors.Select(x => x.Username).ToList(),
                x.PublicationDate,
                x.Availability,
                x.Count,
                Genre = x.Genre.Select(x => x.Name).ToList(),
            })
            .Skip((filter.PageNumber - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .ToListAsync();

        return query.Adapt<List<Book>>();
    }
    public async Task<List<Book>> SearchBookByAuhtorName(string AuthorName, PaginationFilter filter)
    {
        var query = await _libraryDBContext.Books
            .AsNoTracking()
            .Where(x => x.Authors.Any(x => 
            string.IsNullOrEmpty(AuthorName)
            || x.Username.Contains(AuthorName)
            || x.FirstName.Contains(AuthorName)
            || x.LastName.Contains(AuthorName)))
           .Select(x => new
           {
               x.Title,
               Author = x.Authors.Select(x => x.Username).ToList(),
               x.PublicationDate,
               x.Availability,
               x.Count,
               Genre = x.Genre.Select(x => x.Name).ToList(),
           })
            .Skip((filter.PageNumber - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .ToListAsync();

        return query.Adapt<List<Book>>();
    }
}
