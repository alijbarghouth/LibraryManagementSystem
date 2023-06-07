using Application.Cashing;
using Application.Command.BookTransactionCommand;
using Domain.Services.BookTransactionService;

namespace Application.Handler.BookTransactionHandler.CheckOutBook;

public sealed class CheckOutBookCommandHandler : ICheckOutBookCommandHandler
{
    private readonly IBookTransactionService _bookTransactionService;
    private readonly ICashService _cashService;

    public CheckOutBookCommandHandler(IBookTransactionService bookTransactionService,
        ICashService cashService)
    {
        _bookTransactionService = bookTransactionService;
        _cashService = cashService;
    }

    public async Task<string> Handel(CheckOutBookCommand command)
    {
        var key = $"{command.UserId} PatronProfile";
        await _bookTransactionService.CheckOutBook(command.OrderId);
        await _cashService.RemoveAsync(key);
        return "success";
    }
}