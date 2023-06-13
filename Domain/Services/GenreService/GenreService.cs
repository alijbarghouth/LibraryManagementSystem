using Domain.DTOs.GenreDTOs;
using Domain.Repositories.GenreRepository;
using Domain.Repositories.SharedRepositories;
using Domain.Shared.Exceptions;
using Domain.Shared.Exceptions.CustomException;

namespace Domain.Services.GenreService;

public sealed class GenreService : IGenreService
{
    private readonly IGenreRepository _genreRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISharedBookManagementRepository _sharedBookManagementRepository;
    public GenreService(IGenreRepository genreRepository
        , IUnitOfWork unitOfWork, ISharedBookManagementRepository sharedBookManagementRepository)
    {
        _genreRepository = genreRepository;
        _unitOfWork = unitOfWork;
        _sharedBookManagementRepository = sharedBookManagementRepository;
    }

    public async Task<Genre> AddBookGenre(Genre genre, CancellationToken cancellationToken = default)
    {
        if (await _sharedBookManagementRepository.IsGenreExistsByTitle(genre.Name))
            throw new BadRequestException("genre is exists");

        var result = await _genreRepository.AddBookGenre(genre);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return result;
    }
}
