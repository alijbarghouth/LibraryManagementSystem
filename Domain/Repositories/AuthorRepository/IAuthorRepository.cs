using Domain.DTOs.AuthorDTOs;

namespace Domain.Repositories.AuthorRepository;

public interface IAuthorRepository
{
    Task<Author> AddAuthor(Author auhtor);
    Task<Author> UpdateAuthor(Guid authorId, Author author);
    Task<bool> DeleteAuthor(Guid authorId);
}
