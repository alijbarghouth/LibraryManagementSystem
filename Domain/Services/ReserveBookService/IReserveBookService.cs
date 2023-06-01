namespace Domain.Services.ReserveBookService;

public interface IReserveBookService
{
    Task<bool> ReserveBook(Guid bookId, Guid userId, CancellationToken cancellationToken = default);
}
