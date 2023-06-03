using Domain.DTOs.BookDTOs;

namespace Domain.Repositories.BookRepository.BookCrudsRepository;

public interface IBookCrudsRepository
{
    Task<BookRequest> AddBook(BookRequest book);
    Task<bool> DeleteBook(Guid bookId);
    Task<BookRequest> UpdateBook(Guid bookId, BookRequest book);
    Task<List<Book>> GetAllBook();
}