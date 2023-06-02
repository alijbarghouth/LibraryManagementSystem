using Application.Command.BookTransactionCommand;
using Domain.Services.BookTransactionService;

namespace Application.Handler.BookTransactionHandler.CheckOutBook;

public class CheckOutBookCommandHandler : ICheckOutBookCommandHandler
{
    private readonly IBookTransactionService _bookTransactionService;

    public CheckOutBookCommandHandler(IBookTransactionService bookTransactionService)
    {
        _bookTransactionService = bookTransactionService;
    }

    public async Task<string> Handel(CheckOutBookCommand command)
    {
        await _bookTransactionService.CheckOutBook(command.OrderId);
        return "success";
    }
}