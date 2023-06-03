using Domain.DTOs.BookDTOs;

namespace Domain.Services.BookService.BookCruds;

public interface IBookCrudsService
{
    Task<BookRequest> AddBook(BookRequest book, CancellationToken cancellationToken = default);
    Task<bool> DeleteBook(Guid bookId, CancellationToken cancellationToken = default);
    Task<BookRequest> UpdateBook(Guid bookId , BookRequest book, CancellationToken cancellationToken = default);
    Task<List<Book>> GetAllBook();
}