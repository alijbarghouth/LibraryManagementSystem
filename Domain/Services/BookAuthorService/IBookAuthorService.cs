namespace Domain.Services.BookAuthorService;

public interface IBookAuthorService
{
    Task<bool> AddBookAuthor(Domain.DTOs.BookAuthorDTOs.BookAuthor bookAuthor
        , CancellationToken cancellationToken = default);
}
