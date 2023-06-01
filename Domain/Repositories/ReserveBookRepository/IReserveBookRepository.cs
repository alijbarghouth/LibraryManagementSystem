namespace Domain.Repositories.ReserveBookRepository;

public interface IReserveBookRepository
{
    Task<bool> ReserveBook(Guid bookId, Guid userId);
}
