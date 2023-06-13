using Domain.DTOs.BookGenreDTOs;
using Domain.Repositories.BookGenreRepository;
using Domain.Repositories.SharedRepositories;
using Domain.Shared.Exceptions;
using Domain.Shared.Exceptions.CustomException;

namespace Domain.Services.BookGenreService;

public sealed class BookGenreService : IBookGenreService
{
    private readonly IBookGenreRepository _bookGenreRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISharedBookManagementRepository _sharedBookManagementRepository;

    public BookGenreService( IUnitOfWork unitOfWork
        , ISharedBookManagementRepository sharedBookManagementRepository
        , IBookGenreRepository bookGenreRepository)
    {
        _unitOfWork = unitOfWork;
        _sharedBookManagementRepository = sharedBookManagementRepository;
        _bookGenreRepository = bookGenreRepository;
    }

    public async Task<BookGenre> AddBookGenre
        (BookGenre bookGenre, CancellationToken cancellationToken = default)
    {
        if (!await _sharedBookManagementRepository.IsBookExistsByTitle(bookGenre.BookName))
        {
            throw new NotFoundException("book not found");
        }

        foreach (var genreDtos in bookGenre.Genre)
        {
            if (!await _sharedBookManagementRepository.IsGenreExistsByTitle(genreDtos))
                throw new NotFoundException("genre not found");
        }

        var result = await _bookGenreRepository.AddBookGenre(bookGenre);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return result;
    }
}