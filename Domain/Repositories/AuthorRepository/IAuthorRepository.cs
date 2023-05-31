using Domain.DTOs.AuthorDTOs;

namespace Domain.Repositories.AuthorRepository;

public interface IAuthorRepository
{
    Task<Author> AddAuthor(Author auhtor);
}
