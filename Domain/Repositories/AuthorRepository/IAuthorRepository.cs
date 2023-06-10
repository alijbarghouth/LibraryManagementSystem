using Domain.DTOs.AuthorDTOs;
using Domain.DTOs.Response;

namespace Domain.Repositories.AuthorRepository;

public interface IAuthorRepository
{
    Task<Response<Author>> AddAuthor(Author auhtor);
    Task<Response<Author>> UpdateAuthor(Guid authorId, Author author);
    Task<bool> DeleteAuthor(Guid authorId);
}
