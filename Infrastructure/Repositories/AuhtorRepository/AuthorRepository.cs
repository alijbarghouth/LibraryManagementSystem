using Domain.Repositories.AuthorRepository;
using Infrastructure.DBContext;
using Infrastructure.Model;
using Mapster;

namespace Infrastructure.Repositories.AuhtorRepository;

public sealed class AuthorRepository : IAuthorRepository
{
    private readonly LibraryDBContext _libraryDBContext;

    public AuthorRepository(LibraryDBContext libraryDBContext)
    {
        _libraryDBContext = libraryDBContext;
    }

    public async Task<Domain.DTOs.AuthorDTOs.Author> AddAuthor(Domain.DTOs.AuthorDTOs.Author auhtor)
    {
        await _libraryDBContext.Authors.AddAsync(auhtor.Adapt<Author>());
        return auhtor;
    }
}
