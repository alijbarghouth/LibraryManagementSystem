using Domain.DTOs.BookDTOs;
using Domain.DTOs.Response;

namespace Domain.Services.BookService.BookCruds;

public interface IBookCrudsService
{
    Task<Response<BookRequest>> AddBook(BookRequest book, CancellationToken cancellationToken = default);
    Task<bool> DeleteBook(Guid bookId, CancellationToken cancellationToken = default);
    Task<Response<BookRequest>> UpdateBook(Guid bookId, BookRequest book, CancellationToken cancellationToken = default);
    Task<List<Book>> GetAllBook();
}