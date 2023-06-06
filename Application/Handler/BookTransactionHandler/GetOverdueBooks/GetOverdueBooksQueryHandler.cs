using Application.Cashing;
using Domain.DTOs.OrderDTOs;
using Domain.Services.BookTransactionService;
using Domain.Shared.Exceptions.CustomException;

namespace Application.Handler.BookTransactionHandler.GetOverdueBooks;

public sealed class GetOverdueBooksQueryHandler : IGetOverdueBooksQueryHandler
{
    private readonly IBookTransactionService _bookTransactionService;
    private readonly ICashService _cashService;

    public GetOverdueBooksQueryHandler(IBookTransactionService bookTransactionService,
        ICashService cashService)
    {
        _bookTransactionService = bookTransactionService;
        _cashService = cashService;
    }

    public async Task<List<Order>> Handel()
    =>
         await _cashService.GetAsync<List<Order>>("OverdueBooks", async () =>
        {
            var order = await _bookTransactionService.GetOverdueBooks();
            if (order.Count <= 0)
                throw new NoContentException("no order");
            return order;
        });
    
}