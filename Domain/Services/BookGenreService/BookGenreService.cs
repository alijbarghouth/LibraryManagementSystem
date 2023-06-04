using Domain.DTOs.BookGenreDTOs;
using Domain.Repositories.SharedRepositories;
using Domain.Shared.Exceptions;
using Domain.Shared.Exceptions.CustomException;

namespace Domain.Services.BookGenreService;

public sealed class BookGenreService : IBookGenreService
{
    private readonly IBookGenreService _bookGenreService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISharedBookManagementRepository _sharedBookManagementRepository;

    public BookGenreService(IBookGenreService bookGenreService
        , IUnitOfWork unitOfWork
        , ISharedBookManagementRepository sharedBookManagementRepository)
    {
        _bookGenreService = bookGenreService;
        _unitOfWork = unitOfWork;
        _sharedBookManagementRepository = sharedBookManagementRepository;
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
                throw new NotFoundException("author not found");
        }

        var result = await _bookGenreService.AddBookGenre(bookGenre, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return result;
    }
}