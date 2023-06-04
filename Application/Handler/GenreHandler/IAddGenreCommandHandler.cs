using Application.Command.GenreCommand;
using Domain.DTOs.GenreDTOs;

namespace Application.Handler.GenreHandler;

public interface IAddGenreCommandHandler
{
    Task<Genre> Handel(AddGenreCommand command);
}
