using Application.Command.BookTransactionCommand;
using Domain.DTOs.OrderDTOs;

namespace Application.Handler.BookTransactionHandler.RejectReserveBook;

public interface IRejectReserveBookCommandHandler
{
    Task<Order> Handel(RejectReserveBookCommand command);
}