using Domain.Repositories.AuthorRepository;
using Infrastructure.DBContext;
using Infrastructure.Model;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.AuthorRepository;

public sealed class AuthorRepository : IAuthorRepository
{
    private readonly LibraryDBContext _libraryDbContext;

    public AuthorRepository(LibraryDBContext libraryDbContext)
    {
        _libraryDbContext = libraryDbContext;
    }

    public async Task<Domain.DTOs.AuthorDTOs.Author> AddAuthor(Domain.DTOs.AuthorDTOs.Author auhtor)
    {
        await _libraryDbContext.Authors.AddAsync(auhtor.Adapt<Author>());
        return auhtor;
    }

    public async Task<bool> IsAuthorExists(string authorName)
    {
        return await _libraryDbContext.Authors
            .AsNoTracking()
            .AnyAsync(x => x.Username == authorName);
    }
}
