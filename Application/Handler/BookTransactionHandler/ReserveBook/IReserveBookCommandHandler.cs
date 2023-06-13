using Application.Command.BookTransactionCommand;
using Domain.DTOs.OrderDTOs;

namespace Application.Handler.BookTransactionHandler.ReserveBook;

public interface IReserveBookCommandHandler
{
    Task<Order> Handel(ReserveBookCommand command);
}
