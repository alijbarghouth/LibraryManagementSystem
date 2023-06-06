using Application.Command.BookGenreCommand;
using Domain.DTOs.BookGenreDTOs;
using Domain.Services.BookGenreService;

namespace Application.Handler.BookGenreHandler.AddBookGenreCommandHandler;

public sealed class AddBookGenreCommandHandler : IAddBookGenreCommandHandler
{
    private readonly IBookGenreService _bookGenreService;

    public AddBookGenreCommandHandler(IBookGenreService bookGenreService)
    {
        _bookGenreService = bookGenreService;
    }

    public async Task<BookGenre> Handel(AddBookGenreCommand command)
    {
        return await _bookGenreService.AddBookGenre(command.BookGenre);
    }
}