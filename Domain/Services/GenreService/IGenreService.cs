using Domain.DTOs.GenreDTOs;

namespace Domain.Services.GenreService;

public interface IGenreService
{
    Task<Genre> AddBookGenre(Genre genre, CancellationToken cancellationToken = default);
}
