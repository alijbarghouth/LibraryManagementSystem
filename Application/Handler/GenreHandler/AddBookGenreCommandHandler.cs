using Application.Command.GenreCommand;
using Domain.DTOs.GenreDTOs;
using Domain.Services.GenreService;

namespace Application.Handler.GenreHandler;

public sealed class AddBookGenreCommandHandler : IAddBookGenreCommandHandler
{
    private readonly IGenreService _genreService;

    public AddBookGenreCommandHandler(IGenreService genreService)
    {
        _genreService = genreService;
    }

    public async Task<Genre> Handel(AddBookGenreCommand command)
    {
        return await _genreService.AddBookGenre(command.Genre);
    }
}
