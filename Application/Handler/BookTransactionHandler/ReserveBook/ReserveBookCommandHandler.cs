using Application.Cashing;
using Application.Command.BookTransactionCommand;
using Domain.Services.BookTransactionService;

namespace Application.Handler.BookTransactionHandler.ReserveBook;

public sealed class ReserveBookCommandHandler : IReserveBookCommandHandler
{
    private readonly IBookTransactionService _bookTransactionService;
    private readonly ICashService _cashService;
    public ReserveBookCommandHandler(IBookTransactionService bookTransactionService,
        ICashService cashService)
    {
        _bookTransactionService = bookTransactionService;
        _cashService = cashService;
    }

    public async Task<bool> Handel(ReserveBookCommand command)
    {
        var key = $"{command.UserId} PatronProfile";
        var transactionResult =  await _bookTransactionService.ReserveBook(command.BookId,command.UserId);
        await _cashService.RemoveAsync(key);
        return transactionResult;
    }
}
