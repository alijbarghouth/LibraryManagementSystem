using Application.Cashing;
using Application.Command.BookCommand;
using Domain.Services.BookService.BookCruds;

namespace Application.Handler.BookHandler.DeleteBookCommandHandler;

public sealed class DeleteBookCommandHandler : IDeleteBookCommandHandler
{
    private readonly IBookCrudsService _bookCrudsService;
    private readonly ICashService _cashService;

    public DeleteBookCommandHandler(IBookCrudsService bookCrudsService,
        ICashService cashService)
    {
        _bookCrudsService = bookCrudsService;
        _cashService = cashService;
    }

    public async Task<bool> Handel(DeleteBookCommand command)
    {
        var book = await _bookCrudsService.DeleteBook(command.BookId);
        if (book) await _cashService.RemoveAsync("Book");
        return book;
    }
}