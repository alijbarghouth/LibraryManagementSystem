using Application.Command.BookCommand;
using Domain.DTOs.BookDTOs;
using Domain.Services.BookService;

namespace Application.Handler.BookHandler.AddBookCommandHandler;

public class AddBookCommandHandler : IAddBookCommandHandler
{
    private readonly IBookService _bookService;

    public AddBookCommandHandler(IBookService bookService)
    {
        _bookService = bookService;
    }

    public async Task<BookRequest> Handel(AddBookCommand command)
    {
        return await _bookService.AddBook(command.Book);
    }
}