using Domain.DTOs.BookAuthorDTOs;

namespace Domain.Repositories.BookAuthorRepository;

public interface IBookAuthorRepository
{
    Task<BookAuthor> AddBookAuthor(BookAuthor bookAuthor);
}
