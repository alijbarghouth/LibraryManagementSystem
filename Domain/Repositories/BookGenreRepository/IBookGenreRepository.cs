using Domain.DTOs.BookGenreDTOs;

namespace Domain.Repositories.BookGenreRepository;

public interface IBookGenreRepository
{
    Task<BookGenre> AddBookGenre(BookGenre bookGenre);
}