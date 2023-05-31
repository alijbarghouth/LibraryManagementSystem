using Domain.DTOs.BookAuthorDTOs;

namespace Domain.Repositories.BookAuthorRepository;

public interface IBookAuthorRepository
{
    Task<bool> AddBookAuthor(BookAuthor bookAuthor);
}
