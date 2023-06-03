using Application.Command.BookCommand;
using Domain.Services.BookService.BookCruds;

namespace Application.Handler.BookHandler.DeleteBookCommandHandler;

public class DeleteBookCommandHandler  :IDeleteBookCommandHandler
{
    private readonly IBookCrudsService _bookCrudsService;

    public DeleteBookCommandHandler(IBookCrudsService bookCrudsService)
    {
        _bookCrudsService = bookCrudsService;
    }

    public async Task<bool> Handel(DeleteBookCommand command)
    {
        return await _bookCrudsService.DeleteBook(command.BookId);
    }
}