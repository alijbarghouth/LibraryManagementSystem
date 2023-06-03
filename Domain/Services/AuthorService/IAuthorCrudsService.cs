using Domain.DTOs.AuthorDTOs;
namespace Domain.Services.AuthorService;

public interface IAuthorCrudsService
{
    Task<Author> AddAuthor(Author author, CancellationToken cancellationToken = default);
    Task<Author> UpdateAuthor(Guid authorId, Author author
        , CancellationToken cancellationToken = default);
    Task<bool> DeleteAuthor(Guid authorId, CancellationToken cancellationToken  =default);
}
