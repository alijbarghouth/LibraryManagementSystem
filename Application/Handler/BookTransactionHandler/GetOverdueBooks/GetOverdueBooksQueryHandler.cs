using Application.Cashing;
using Domain.DTOs.OrderDTOs;
using Domain.Services.BookTransactionService;
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

    public async Task<List<OverdueBook>> Handel()
    {
        return await _cashService.GetAsync("OverdueBooks", async () =>
        {
            var orders = await _bookTransactionService.GetOverdueBooks();
            if (orders.Count <= 0)
                throw new NoContentException("no order");
            return orders;
        });
    }
}