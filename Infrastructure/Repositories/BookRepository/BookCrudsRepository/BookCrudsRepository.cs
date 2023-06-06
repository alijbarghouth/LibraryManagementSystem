using Domain.DTOs.Response;
using Domain.Repositories.BookRepository.BookCrudsRepository;
using Domain.Shared.Exceptions.CustomException;
using Infrastructure.DBContext;
using Infrastructure.Model;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.BookRepository.BookCrudsRepository;

public sealed class BookCrudsRepository : IBookCrudsRepository
{
    private readonly LibraryDbContext _libraryDbContext;

    public BookCrudsRepository(LibraryDbContext libraryDbContext)
    {
        _libraryDbContext = libraryDbContext;
    }

    public async Task<Response<Domain.DTOs.BookDTOs.BookRequest>> AddBook
        (Domain.DTOs.BookDTOs.BookRequest bookRequest)
    {
        var book = bookRequest.Adapt<Book>();
        await _libraryDbContext.Books.AddAsync(book);
        return new Response<Domain.DTOs.BookDTOs.BookRequest>(bookRequest, book.Id);
    }

    public async Task<bool> DeleteBook(Guid bookId)
    {
        var book = await _libraryDbContext.Books.FindAsync(bookId)
                   ?? throw new NotFoundException("book not found");
        _libraryDbContext.Books.Remove(book);
        return true;
    }

    public async Task<Response<Domain.DTOs.BookDTOs.BookRequest>> UpdateBook
        (Guid bookId, Domain.DTOs.BookDTOs.BookRequest bookRequest)
    {
        var oldBook = await _libraryDbContext.Books
            .FindAsync(bookId);
        var newBook = bookRequest.Adapt(oldBook);
        _libraryDbContext.Books
            .Update(newBook);
        return new Response<Domain.DTOs.BookDTOs.BookRequest>(bookRequest, newBook.Id);
    }

    public async Task<List<Response<Domain.DTOs.BookDTOs.Book>>> GetAllBook()
    {
        return (await _libraryDbContext.Books
            .Include(x => x.Genre)
            .Include(x => x.Authors)
            .AsNoTracking()
            .Select(x
                =>
                new Response<Domain.DTOs.BookDTOs.Book>(x.Adapt<Domain.DTOs.BookDTOs.Book>(), x.Id)
            )
            .ToListAsync());
    }
}