using Domain.DTOs.GenreDTOs;
using Domain.Repositories.GenreRepository;
using Domain.Shared.Exceptions;
using Domain.Shared.Exceptions.CustomException;

namespace Domain.Services.GenreService;

public sealed class GenreService : IGenreService
{
    private readonly IGenreRepository _genreRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GenreService(IGenreRepository genreRepository, IUnitOfWork unitOfWork)
    {
        _genreRepository = genreRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Genre> AddBookGenre(Genre genre, CancellationToken cancellationToken = default)
    {
        if (await _genreRepository.IsBookGenreExists(genre.Name))
            throw new BadRequestException("author is exists");

        var result = await _genreRepository.AddBookGenre(genre);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return result;
    }
}
