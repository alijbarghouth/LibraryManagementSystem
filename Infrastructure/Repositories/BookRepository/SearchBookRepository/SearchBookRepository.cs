using Domain.DTOs.PaginationsDTOs;
using Domain.Repositories.BookRepository.SearchBookRepository;
using Infrastructure.DBContext;
using Infrastructure.Model;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.BookRepository.SearchBookRepository;

public sealed class SearchBookRepository : ISearchBookRepository
{
    private readonly LibraryDbContext _libraryDbContext;

    public SearchBookRepository(LibraryDbContext libraryDbContext)
    {
        _libraryDbContext = libraryDbContext;
    }

    public async Task<List<Domain.DTOs.BookDTOs.Book>> SearchBookByTitle
        (string bookTitle, PaginationFilter filter)
    {
        var query = await _libraryDbContext.Books
            .AsNoTracking()
            .Include(x=>x.Authors)
            .Include(x=> x.Genres)
            .Where(x => string.IsNullOrEmpty(bookTitle) || x.Title.Contains(bookTitle))
            .Select(x => new
            {
                x.Title,
                Authors = x.Authors.ToList(),
                x.PublicationDate,
                x.BookStatus,
                x.Count,
                Genres = x.Genres.ToList(),
            })
            .Skip((filter.PageNumber - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .ToListAsync();

        return query.Adapt<List<Domain.DTOs.BookDTOs.Book>>();
    }

    public async Task<List<Domain.DTOs.BookDTOs.Book>> SearchBookByAuthorName
        (string authorName, PaginationFilter filter)
    {
        var query = await _libraryDbContext.Books
            .AsNoTracking()
            .Include(x=> x.Authors)
            .Include(x=> x.Genres)
            .Where(x => x.Authors.Any(x =>
                string.IsNullOrEmpty(authorName)
                || x.Username.Contains(authorName)))
            .Select(x => new
            {
                x.Title,
                Authors = x.Authors.ToList(),
                x.PublicationDate,
                x.BookStatus,
                x.Count,
                Genres = x.Genres.ToList(),
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
            .Include(x=> x.Authors)
            .Include(x=> x.Genres)
            .Where(x => x.Genres.Any(x =>
                string.IsNullOrEmpty(bookGenre)
                || x.Name.Contains(bookGenre)))
            .Select(x => new
            {
                x.Title,
                Authors = x.Authors.ToList(),
                x.PublicationDate,
                x.BookStatus,
                x.Count,
                Genres = x.Genres.ToList(),
            })
            .Skip((filter.PageNumber - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .ToListAsync();

        return query.Adapt<List<Domain.DTOs.BookDTOs.Book>>();
    }
}