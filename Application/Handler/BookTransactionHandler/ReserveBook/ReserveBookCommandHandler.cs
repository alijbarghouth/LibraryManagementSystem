using Application.Command.BookTransactionCommand;
using Domain.Services.BookTransactionService;

namespace Application.Handler.BookTransactionHandler.ReserveBook;

public sealed class ReserveBookCommandHandler : IReserveBookCommandHandler
{
    private readonly IBookTransactionService _bookTransactionService;

    public ReserveBookCommandHandler(IBookTransactionService bookTransactionService)
    {
        _bookTransactionService = bookTransactionService;
    }

    public async Task<bool> Handel(ReserveBookCommand command)
    {
        return await _bookTransactionService.ReserveBook(command.BookId,command.UserId);   
    }
}
