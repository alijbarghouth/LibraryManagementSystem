using Domain.DTOs.OrderDTOs;

namespace Domain.Repositories.BookTransactionRepository;

public interface IBookTransactionRepository
{
    Task<Order> ReserveBook(Guid bookId, Guid userId);
    Task<Order> CheckOutBook(Guid orderId);
    Task<Order> AcceptReturnedBook(Guid orderId);
    Task<Order> RejectReserveBook(Guid orderId);
    Task<List<Order>> GetOverdueBooks();
}
