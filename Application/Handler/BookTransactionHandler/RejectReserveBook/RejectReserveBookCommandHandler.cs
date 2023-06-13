using Application.Command.BookTransactionCommand;
using Domain.DTOs.OrderDTOs;
using Domain.Services.BookTransactionService;

namespace Application.Handler.BookTransactionHandler.RejectReserveBook;

public sealed class RejectReserveBookCommandHandler : IRejectReserveBookCommandHandler
{
    private readonly IBookTransactionService _bookTransactionService;

    public RejectReserveBookCommandHandler(IBookTransactionService bookTransactionService)
    {
        _bookTransactionService = bookTransactionService;
    }

    public async Task<Order> Handel(RejectReserveBookCommand command)
    {
        return await _bookTransactionService.RejectReserveBook(command.OrderId);
    }
}