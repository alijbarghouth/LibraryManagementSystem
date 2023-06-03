using Domain.DTOs.PaginationsDTOs;
using Domain.Repositories.BookRepository.SearchBookRepository;
using Infrastructure.DBContext;
using Infrastructure.Model;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.BookRepository.SearchBookRepository;

public sealed class SearchBookRepository : ISearchBookRepository
{
    private readonly LibraryDBContext _libraryDbContext;

    public SearchBookRepository(LibraryDBContext libraryDbContext)
    {
        _libraryDbContext = libraryDbContext;
    }

    public async Task<List<Domain.DTOs.BookDTOs.Book>> SearchBookByTitle
        (string bookTitle, PaginationFilter filter)
    {
        var query = await _libraryDbContext.Books
            .AsNoTracking()
            .Where(x => string.IsNullOrEmpty(bookTitle) || x.Title.Contains(bookTitle))
            .Select(x => new
            {
                x.Title,
                Author = x.Authors.Select(a => a.Username).ToList(),
                x.PublicationDate,
                x.BookStatus,
                x.Count,
                Genre = x.Genre.Select(g => g.Name).ToList(),
            })
            .Skip((filter.PageNumber - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .ToListAsync();

        return query.Adapt<List<Domain.DTOs.BookDTOs.Book>>();
    }

    public async Task<List<Domain.DTOs.BookDTOs.Book>> SearchBookByAuhtorName
        (string authorName, PaginationFilter filter)
    {
        var query = await _libraryDbContext.Books
            .AsNoTracking()
            .Where(x => x.Authors.Any(x =>
                string.IsNullOrEmpty(authorName)
                || x.Username.Contains(authorName)))
            .Select(x => new
            {
                x.Title,
                Author = x.Authors.Select(x => x.Username).ToList(),
                x.PublicationDate,
                x.BookStatus,
                x.Count,
                Genre = x.Genre.Select(x => x.Name).ToList(),
            })
            .Skip((filter.PageNumber - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .ToListAsync();

        return query.Adapt<List<Domain.DTOs.BookDTOs.Book>>();
    }

    public async Task<List<Domain.DTOs.BookDTOs.Book>> SearchBookByBookGenre
        (string bookGenre, PaginationFilter filter)
    {
        var query = await _libraryDbContext.Books
            .AsNoTracking()
            .Where(x => x.Genre.Any(x =>
                string.IsNullOrEmpty(bookGenre)
                || x.Name.Contains(bookGenre)))
            .Select(x => new
            {
                x.Title,
                Author = x.Authors.Select(x => x.Username).ToList(),
                x.PublicationDate,
                x.BookStatus,
                x.Count,
                Genre = x.Genre.Select(x => x.Name).ToList(),
            })
            .Skip((filter.PageNumber - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .ToListAsync();

        return query.Adapt<List<Domain.DTOs.BookDTOs.Book>>();
    }
}