using Application.Cashing;
using Application.Command.BookTransactionCommand;
using Domain.Services.BookTransactionService;

namespace Application.Handler.BookTransactionHandler.AcceptReturnedBook;

public sealed class AcceptReturnedBookCommandHandler :IAcceptReturnedBookCommandHandler
{
    private readonly IBookTransactionService _bookTransactionService;
    private readonly ICashService _cashService;

    public AcceptReturnedBookCommandHandler(IBookTransactionService bookTransactionService,
        ICashService cashService)
    {
        _bookTransactionService = bookTransactionService;
        _cashService = cashService;
    }

    public async Task<string> Handel(AcceptReturnedBookCommand command)
    {
        var key = $"{command.UserId} PatronProfile";
        await _bookTransactionService.AcceptReturnedBook(command.OrderId);
        await _cashService.RemoveAsync(key);
        return "success";
    }
}