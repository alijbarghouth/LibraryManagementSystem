using Domain.DTOs.BookAuthorDTOs;
using Domain.Repositories.BookAuthorRepository;
using Domain.Shared.Exceptions.CustomException;
using Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.BookAuthorRepository;

public sealed class BookAuthorRepository : IBookAuthorRepository
{
    private readonly LibraryDbContext _libraryDbContext;

    public BookAuthorRepository(LibraryDbContext libraryDbContext)
    {
        _libraryDbContext = libraryDbContext;
    }

    public async Task<BookAuthor> AddBookAuthor(BookAuthor bookAuthor)
    {
        var book = await _libraryDbContext.Books
            .SingleOrDefaultAsync(x => x.Title == bookAuthor.BookName)
            ?? throw new NotFoundException("book not found");

        foreach (var authorDto in bookAuthor.AuthorName)
        {
            var author = await _libraryDbContext.Authors.SingleOrDefaultAsync(x => x.Username == authorDto)
                 ?? throw new NotFoundException("author not found"); ;
            book.Authors.Add(author);
        }
        _libraryDbContext.Books.Update(book);

        return bookAuthor;
    }
}
