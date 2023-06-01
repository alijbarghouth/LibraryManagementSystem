using Application.Command.ReserveBookCommand;
using Domain.Services.ReserveBookService;

namespace Application.Handler.ReserveBookHandler;

public sealed class ReserveBookCommandHandler : IReserveBookCommandHandler
{
    private readonly IReserveBookService _reserveBookService;

    public ReserveBookCommandHandler(IReserveBookService reserveBookService)
    {
        _reserveBookService = reserveBookService;
    }

    public async Task<bool> ReserveBook(ReserveBookCommand command)
    {
        return await _reserveBookService.ReserveBook(command.BookId,command.UserId);   
    }
}
