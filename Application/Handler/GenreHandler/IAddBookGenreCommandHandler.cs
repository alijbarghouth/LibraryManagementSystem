using Application.Command.GenreCommand;
using Domain.DTOs.GenreDTOs;

namespace Application.Handler.GenreHandler;

public interface IAddBookGenreCommandHandler
{
    Task<Genre> Handel(AddBookGenreCommand command);
}
