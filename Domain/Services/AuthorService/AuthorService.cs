using Domain.DTOs.AuthorDTOs;
using Domain.Repositories.AuthorRepository;
using Domain.Shared.Exceptions;
using Domain.Shared.Exceptions.CustomException;

namespace Domain.Services.AuthorService;

public sealed class AuthorService : IAuthorService
{
    private readonly IAuthorRepository _authorRepository;
    private readonly IUnitOfWork _unitOfWork;
    public AuthorService(IAuthorRepository authorRepository, IUnitOfWork unitOfWork)
    {
        _authorRepository = authorRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Author> AddAuthor(Author author, CancellationToken cancellationToken = default)
    {
        if (await _authorRepository.IsAuthorExists(author.Username))
            throw new BadRequestException("author is exists");

        var result = await _authorRepository.AddAuthor(author);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return result;
    }
}
