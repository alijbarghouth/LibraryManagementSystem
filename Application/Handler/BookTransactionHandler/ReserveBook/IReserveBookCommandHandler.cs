using Application.Command.BookTransactionCommand;

namespace Application.Handler.BookTransactionHandler.ReserveBook;

public interface IReserveBookCommandHandler
{
    Task<bool> Handel(ReserveBookCommand command);
}
