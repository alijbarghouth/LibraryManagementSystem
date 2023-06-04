using Domain.DTOs.BookGenreDTOs;
using Domain.Repositories.BookGenreRepository;
using Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.BookGenreRepository;

public sealed class BookGenreRepository : IBookGenreRepository
{
    private readonly LibraryDBContext _libraryDbContext;

    public BookGenreRepository(LibraryDBContext libraryDbContext)
    {
        _libraryDbContext = libraryDbContext;
    }

    public async Task<BookGenre> AddBookGenre(BookGenre bookGenre)
    {
        var book = await _libraryDbContext.Books
            .SingleOrDefaultAsync(x => x.Title == bookGenre.BookName);

        foreach (var genreDtos in bookGenre.Genre)
        {
            var genre = await _libraryDbContext.Authors.SingleOrDefaultAsync(x => x.Username == genreDtos);
            book.Authors.Add(genre);
        }
        _libraryDbContext.Books.Update(book);

        return bookGenre; 
    }
}