using Domain.DTOs.BookDTOs;
using Domain.DTOs.Response;

namespace Domain.Repositories.BookRepository.BookCrudsRepository;

public interface IBookCrudsRepository
{
    Task<Response<BookRequest>> AddBook(BookRequest book);
    Task<bool> DeleteBook(Guid bookId);
    Task<Response<BookRequest>> UpdateBook(Guid bookId, BookRequest book);
    Task<List<Response<Book>>> GetAllBook();
}