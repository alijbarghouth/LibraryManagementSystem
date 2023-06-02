using Application.Command.BookTransactionCommand;
using Domain.Services.BookTransactionService;

namespace Application.Handler.BookTransactionHandler.AcceptReturnedBook;

public class AcceptReturnedBookCommandHandler :IAcceptReturnedBookCommandHandler
{
    private readonly IBookTransactionService _bookTransactionService;

    public AcceptReturnedBookCommandHandler(IBookTransactionService bookTransactionService)
    {
        _bookTransactionService = bookTransactionService;
    }

    public async Task<string> Handel(AcceptReturnedBookCommand command)
    {
        await _bookTransactionService.AcceptReturnedBook(command.OrderId);
        return "success";
    }
}