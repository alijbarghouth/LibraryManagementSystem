using Domain.DTOs.BookGenreDTOs;
using Domain.Repositories.BookGenreRepository;
using Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.BookGenreRepository;

public sealed class BookGenreRepository : IBookGenreRepository
{
    private readonly LibraryDbContext _libraryDbContext;

    public BookGenreRepository(LibraryDbContext libraryDbContext)
    {
        _libraryDbContext = libraryDbContext;
    }

    public async Task<BookGenre> AddBookGenre(BookGenre bookGenre)
    {
        var book = await _libraryDbContext.Books
            .SingleAsync(x => x.Title == bookGenre.BookName);

        foreach (var genreDtos in bookGenre.Genre)
        {
            var genre = await _libraryDbContext.Genres
                .SingleAsync(x => x.Name == genreDtos);
            book.Genres.Add(genre);
        }
        _libraryDbContext.Books.Update(book);

        return bookGenre; 
    }
}