using Domain.DTOs.Response;
using Domain.Repositories.AuthorRepository;
using Domain.Shared.Exceptions.CustomException;
using Infrastructure.DBContext;
using Infrastructure.Model;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.AuthorRepository;

public sealed class AuthorRepository : IAuthorRepository
{
    private readonly LibraryDbContext _libraryDbContext;

    public AuthorRepository(LibraryDbContext libraryDbContext)
    {
        _libraryDbContext = libraryDbContext;
    }

    public async Task<Response<Domain.DTOs.AuthorDTOs.Author>> AddAuthor
        (Domain.DTOs.AuthorDTOs.Author author)
    {
        var newAuthor = author.Adapt<Author>();
        await _libraryDbContext.Authors.AddAsync(newAuthor);
        return new Response<Domain.DTOs.AuthorDTOs.Author>(author, newAuthor.Id);
    }

    public async Task<Response<Domain.DTOs.AuthorDTOs.Author>> UpdateAuthor(Guid authorId,
        Domain.DTOs.AuthorDTOs.Author author)
    {
        var oldAuthor = await _libraryDbContext.Authors
            .FindAsync(authorId);
        var newAuthor = author.Adapt(oldAuthor);
        if (await _libraryDbContext.Authors
                .SingleOrDefaultAsync
                    (x => x.Username == newAuthor.Username) is not null)
        {
            throw new BadRequestException("author name is exists");
        }

        _libraryDbContext.Authors.Update(newAuthor);
        return new Response<Domain.DTOs.AuthorDTOs.Author>(author, newAuthor.Id);
    }

    public async Task<bool> DeleteAuthor(Guid authorId)
    {
        var author = await _libraryDbContext.Authors
            .FindAsync(authorId);
        _libraryDbContext.Authors.Remove(author);
        return true;
    }

    public async Task<List<Response<Domain.DTOs.AuthorDTOs.Author>>> GetAuthorByBookId(Guid bookId)
    {
        return await _libraryDbContext.Books
           .Include(x => x.Authors)
           .AsNoTracking()
           .Where(x => x.Id == bookId)
           .SelectMany(x =>
               x.Authors.Select(y =>
                   new Response<Domain.DTOs.AuthorDTOs.Author>(y.Adapt<Domain.DTOs.AuthorDTOs.Author>(), y.Id)
               )
           )
           .ToListAsync();
    }
}