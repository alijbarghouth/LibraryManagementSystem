using Application.Command.ReserveBookCommand;

namespace Application.Handler.ReserveBookHandler;

public interface IReserveBookCommandHandler
{
    Task<bool> ReserveBook(ReserveBookCommand command);
}
