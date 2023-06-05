using Domain.DTOs.AuthorDTOs;
using Domain.DTOs.Response;

namespace Domain.Services.AuthorService;

public interface IAuthorCrudsService
{
    Task<Response<Author>> AddAuthor(Author author, CancellationToken cancellationToken = default);
    Task<Response<Author>> UpdateAuthor(Guid authorId, Author author
        , CancellationToken cancellationToken = default);
    Task<bool> DeleteAuthor(Guid authorId, CancellationToken cancellationToken  =default);
}
