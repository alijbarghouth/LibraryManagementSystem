using Application.Command.BookAuthorCommand;
using Domain.DTOs.BookAuthorDTOs;
using Domain.Services.BookAuthorService;

namespace Application.Handler.BookAuthorHandler;

public sealed class BookAuthorCommandHandler : IBookAuthorCommandHandler
{
    private readonly IBookAuthorService _bookAuthorService;

    public BookAuthorCommandHandler(IBookAuthorService bookAuthorService)
    {
        _bookAuthorService = bookAuthorService;
    }

    public async Task<bool> Handel(BookAuthorCommand command)
    {
        return await _bookAuthorService.AddBookAuthor(command.BookAuthor);
    }
}
