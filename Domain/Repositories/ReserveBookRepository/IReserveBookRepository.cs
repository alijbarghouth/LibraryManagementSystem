using Domain.DTOs.OrderDTOs;

namespace Domain.Repositories.ReserveBookRepository;

public interface IReserveBookRepository
{
    Task<bool> ReserveBook(Guid bookId, Guid userId);
    Task CheckOutBook(Guid orderId);
    Task AcceptReturnedBook(Guid orderId);
    Task<List<Order>> GetOverdueBooks();
}
