using Application.Command.GenreCommand;
using Domain.DTOs.GenreDTOs;
using Domain.Services.GenreService;

namespace Application.Handler.GenreHandler;

public sealed class AddGenreCommandHandler : IAddGenreCommandHandler
{
    private readonly IGenreService _genreService;

    public AddGenreCommandHandler(IGenreService genreService)
    {
        _genreService = genreService;
    }

    public async Task<Genre> Handel(AddGenreCommand command)
    {
        return await _genreService.AddBookGenre(command.Genre);
    }
}
