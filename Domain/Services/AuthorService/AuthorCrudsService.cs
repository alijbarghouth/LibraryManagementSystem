using Domain.DTOs.AuthorDTOs;
using Domain.Repositories.AuthorRepository;
using Domain.Repositories.SharedRepositories;
using Domain.Shared.Exceptions;
using Domain.Shared.Exceptions.CustomException;

namespace Domain.Services.AuthorService;

public sealed class AuthorCrudsService : IAuthorCrudsService
{
    private readonly IAuthorRepository _authorRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISharedRepository _sharedRepository;

    public AuthorCrudsService(IAuthorRepository authorRepository
        , IUnitOfWork unitOfWork, ISharedRepository sharedRepository)
    {
        _authorRepository = authorRepository;
        _unitOfWork = unitOfWork;
        _sharedRepository = sharedRepository;
    }

    public async Task<Author> AddAuthor(Author author, CancellationToken cancellationToken = default)
    {
        if (await _sharedRepository.IsAuthorExistsByAuthorName(author.Username))
            throw new BadRequestException("author is exists");
        var result = await _authorRepository.AddAuthor(author);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return result;
    }

    public async Task<Author> UpdateAuthor(Guid authorId, Author author, CancellationToken cancellationToken = default)
    {
        if (await _sharedRepository.IsAuthorExistsByAuthorName(author.Username))
            throw new BadRequestException("author is exists");
        var result = await _authorRepository.UpdateAuthor(authorId,author);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return result;
    }

    public async Task<bool> DeleteAuthor(Guid authorId
        , CancellationToken cancellationToken  =default)
    {
        if (!await _sharedRepository.IsAuthorExistsByAuthorId(authorId))
            throw new BadRequestException("author is not exists");
        var result = await _authorRepository.DeleteAuthor(authorId);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return result;
    }
}