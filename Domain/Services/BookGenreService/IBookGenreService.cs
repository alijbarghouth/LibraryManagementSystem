using Domain.DTOs.BookGenreDTOs;

namespace Domain.Services.BookGenreService;

public interface IBookGenreService
{
    Task<BookGenre> AddBookGenre
        (BookGenre bookGenre, CancellationToken cancellationToken = default);
}