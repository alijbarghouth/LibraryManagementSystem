using Domain.DTOs.OrderDTOs;
using Domain.Services.BookTransactionService;

namespace Application.Handler.BookTransactionHandler.GetOverdueBooks;

public class GetOverdueBooksQueryHandler : IGetOverdueBooksQueryHandler
{
    private readonly IBookTransactionService _bookTransactionService;

    public GetOverdueBooksQueryHandler(IBookTransactionService bookTransactionService)
    {
        _bookTransactionService = bookTransactionService;
    }

    public async Task<List<Order>> Handel()
    {
        return await _bookTransactionService.GetOverdueBooks();
    }
}