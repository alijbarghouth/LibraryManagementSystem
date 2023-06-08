using Domain.DTOs.OrderDTOs;

namespace Domain.Services.BookTransactionService;

public interface IBookTransactionService 
{
    Task<Order> ReserveBook(Guid bookId, Guid userId, CancellationToken cancellationToken = default);
    Task<Order> CheckOutBook(Guid orderId);
    Task<Order> AcceptReturnedBook(Guid orderId);
    Task<List<Order>> GetOverdueBooks();
}
