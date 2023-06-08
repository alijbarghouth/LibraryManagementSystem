using Application.Cashing;
using Domain.DTOs.OrderDTOs;
using Domain.Services.BookTransactionService;
using Domain.Services.NotificationService;
using Domain.Shared.Exceptions.CustomException;

namespace Application.Handler.BookTransactionHandler.GetOverdueBooks;

public sealed class GetOverdueBooksQueryHandler : IGetOverdueBooksQueryHandler
{
    private readonly IBookTransactionService _bookTransactionService;
    private readonly ICashService _cashService;

    public GetOverdueBooksQueryHandler
    (IBookTransactionService bookTransactionService,
        ICashService cashService)
    {
        _bookTransactionService = bookTransactionService;
        _cashService = cashService;
    }

    public async Task<List<Order>> Handel()
    {
        return await _cashService.GetAsync<List<Order>>("OverdueBooks", async () =>
        {
            var orders = await _bookTransactionService.GetOverdueBooks();
            if (orders.Count <= 0)
                throw new NoContentException("no order");
            return orders;
        });
    }
}