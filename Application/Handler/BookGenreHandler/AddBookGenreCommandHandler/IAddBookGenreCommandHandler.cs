using Application.Command.BookGenreCommand;
using Domain.DTOs.BookGenreDTOs;

namespace Application.Handler.BookGenreHandler.AddBookGenreCommandHandler;

public interface IAddBookGenreCommandHandler
{
    Task<BookGenre> Handel(AddBookGenreCommand command);
}