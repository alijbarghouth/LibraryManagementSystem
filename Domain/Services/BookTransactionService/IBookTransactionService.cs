using Domain.DTOs.OrderDTOs;

namespace Domain.Services.BookTransactionService;

public interface IBookTransactionService
{
    Task<Order> ReserveBook(Guid bookId, Guid userId, CancellationToken cancellationToken = default);
    Task<Order> CheckOutBook(Guid orderId, CancellationToken cancellationToken);
    Task<Order> AcceptReturnedBook(Guid orderId, CancellationToken cancellationToken);
    Task<Order> RejectReserveBook(Guid orderId, CancellationToken cancellationToken = default);
    Task<List<OverdueBook>> GetOverdueBooks();
}