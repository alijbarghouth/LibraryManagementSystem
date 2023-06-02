using Domain.DTOs.OrderDTOs;

namespace Application.Handler.BookTransactionHandler.GetOverdueBooks;

public interface IGetOverdueBooksQueryHandler
{
    Task<List<Order>> Handel();
}