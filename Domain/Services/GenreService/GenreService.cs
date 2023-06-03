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
    private readonly ISharedRepository _sharedRepository;
    public GenreService(IGenreRepository genreRepository, IUnitOfWork unitOfWork, ISharedRepository sharedRepository)
    {
        _genreRepository = genreRepository;
        _unitOfWork = unitOfWork;
        _sharedRepository = sharedRepository;
    }

    public async Task<Genre> AddBookGenre(Genre genre, CancellationToken cancellationToken = default)
    {
        if (await _sharedRepository.IsBookGenreExists(genre.Name))
            throw new BadRequestException("author is exists");

        var result = await _genreRepository.AddBookGenre(genre);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return result;
    }
}
