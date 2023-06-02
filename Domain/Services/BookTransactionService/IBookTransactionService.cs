using Domain.DTOs.OrderDTOs;

namespace Domain.Services.BookTransactionService;

public interface IBookTransactionService 
{
    Task<bool> ReserveBook(Guid bookId, Guid userId, CancellationToken cancellationToken = default);
    Task CheckOutBook(Guid orderId);
    Task AcceptReturnedBook(Guid orderId);
    Task<List<Order>> GetOverdueBooks();
}
