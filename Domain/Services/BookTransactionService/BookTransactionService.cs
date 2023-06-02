using Domain.DTOs.OrderDTOs;
using Domain.Repositories.ReserveBookRepository;
using Domain.Shared.Exceptions;

namespace Domain.Services.BookTransactionService;

public sealed class BookTransactionService : IBookTransactionService
{
    private readonly IBookTransactionRepository _bookTransactionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public BookTransactionService(IBookTransactionRepository bookTransactionRepository, IUnitOfWork unitOfWork)
    {
        _bookTransactionRepository = bookTransactionRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> ReserveBook(Guid bookId, Guid userId, CancellationToken cancellationToken = default)
    {
        var result = await _bookTransactionRepository.ReserveBook(bookId, userId);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return result;
    }

    public async Task CheckOutBook(Guid orderId)
    {
        await _bookTransactionRepository.CheckOutBook(orderId);
    }

    public async Task AcceptReturnedBook(Guid orderId)
    {
        await _bookTransactionRepository.AcceptReturnedBook(orderId);
    }

    public async Task<List<Order>> GetOverdueBooks()
    {
        return await _bookTransactionRepository.GetOverdueBooks();
    }
}