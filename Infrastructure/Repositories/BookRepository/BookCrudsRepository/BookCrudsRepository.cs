using Domain.Repositories.BookRepository.BookCrudsRepository;
using Domain.Shared.Exceptions.CustomException;
using Infrastructure.DBContext;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Book = Infrastructure.Model.Book;

namespace Infrastructure.Repositories.BookRepository.BookCrudsRepository;

public class BookCrudsRepository : IBookCrudsRepository
{
    private readonly LibraryDBContext _libraryDbContext;

    public BookCrudsRepository(LibraryDBContext libraryDbContext)
    {
        _libraryDbContext = libraryDbContext;
    }

    public async Task<Domain.DTOs.BookDTOs.BookRequest> AddBook
        (Domain.DTOs.BookDTOs.BookRequest book)
    {
        await _libraryDbContext.Books.AddAsync(book.Adapt<Book>());
        return book;
    }

    public async Task<bool> DeleteBook(Guid bookId)
    {
        var book = await _libraryDbContext.Books.FindAsync(bookId)
                   ?? throw new NotFoundException("book not found");
        _libraryDbContext.Books.Remove(book);
        return true;
    }

    public async Task<Domain.DTOs.BookDTOs.BookRequest> UpdateBook
        (Guid bookId, Domain.DTOs.BookDTOs.BookRequest bookRequest)
    {
        var book = await _libraryDbContext.Books
            .FindAsync(bookId);
        book.Adapt(bookRequest);
        _libraryDbContext.Books
            .Update(book);
        return bookRequest;
    }

    public async Task<List<Domain.DTOs.BookDTOs.Book>> GetAllBook()
    {
        return (await _libraryDbContext.Books
            .AsNoTracking()
            .ToListAsync())
            .Adapt<List<Domain.DTOs.BookDTOs.Book>>();
    }
}