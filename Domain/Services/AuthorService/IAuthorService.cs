using Domain.DTOs.AuthorDTOs;
namespace Domain.Services.AuthorService;

public interface IAuthorService
{
    Task<Author> AddAuthor(Author author, CancellationToken cancellationToken = default);
}
