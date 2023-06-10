using Domain.DTOs.BookAuthorDTOs;

namespace Domain.Services.BookAuthorService;

public interface IBookAuthorService
{
    Task<BookAuthor> AddBookAuthor(BookAuthor bookAuthor
        , CancellationToken cancellationToken = default);
}
