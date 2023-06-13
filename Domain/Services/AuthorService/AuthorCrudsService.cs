using Domain.DTOs.AuthorDTOs;
using Domain.DTOs.Response;
using Domain.Repositories.AuthorRepository;
using Domain.Repositories.SharedRepositories;
using Domain.Shared.Exceptions;
using Domain.Shared.Exceptions.CustomException;

namespace Domain.Services.AuthorService;

public sealed class AuthorCrudsService : IAuthorCrudsService
{
    private readonly IAuthorRepository _authorRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISharedBookManagementRepository _sharedBookManagementRepository;

    public AuthorCrudsService(IAuthorRepository authorRepository
        , IUnitOfWork unitOfWork, ISharedBookManagementRepository managementRepository)
    {
        _authorRepository = authorRepository;
        _unitOfWork = unitOfWork;
        _sharedBookManagementRepository = managementRepository;
    }

    public async Task<Response<Author>> AddAuthor(Author author, CancellationToken cancellationToken = default)
    {
        if (await _sharedBookManagementRepository.IsAuthorExistsByAuthorName(author.Username))
            throw new BadRequestException("author is exists");
        var result = await _authorRepository.AddAuthor(author);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return result;
    }

    public async Task<Response<Author>> UpdateAuthor(Guid authorId, Author author, CancellationToken cancellationToken = default)
    {
        if (!await _sharedBookManagementRepository.IsAuthorExistsByAuthorId(authorId))
            throw new NotFoundException("author is not exists");
        var result = await _authorRepository.UpdateAuthor(authorId, author);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return result;
    }

    public async Task<bool> DeleteAuthor(Guid authorId
        , CancellationToken cancellationToken = default)
    {
        if (!await _sharedBookManagementRepository.IsAuthorExistsByAuthorId(authorId))
            throw new BadRequestException("author is not exists");
        var result = await _authorRepository.DeleteAuthor(authorId);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return result;
    }

    public async Task<List<Response<Author>>> GetAuthorByBookId(Guid bookId)
    {
        if (!await _sharedBookManagementRepository.IsBookExistsByBookId(bookId))
            throw new NotFoundException("book not found");
        return await _authorRepository.GetAuthorByBookId(bookId);
    }
}