using Domain.DTOs.GenreDTOs;

namespace Domain.Repositories.GenreRepository;

public interface IGenreRepository
{
    Task<Genre> AddBookGenre(Genre genre);
    Task<bool> IsBookGenreExists(string bookGenre);
    Task<bool> IsBookGenreExistsById(Guid genreId);
}
