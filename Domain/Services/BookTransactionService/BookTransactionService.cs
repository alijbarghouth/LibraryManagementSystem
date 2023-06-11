using Domain.DTOs.OrderDTOs;
using Domain.Repositories.ReserveBookRepository;
using Domain.Repositories.SharedRepositories;
using Domain.Shared.Exceptions;
using Domain.Shared.Exceptions.CustomException;

namespace Domain.Services.BookTransactionService;

public sealed class BookTransactionService : IBookTransactionService
{
    private readonly IBookTransactionRepository _bookTransactionRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISharedUserRepository _sharedUserRepository;
    private readonly ISharedBookManagementRepository _sharedBookManagementRepository;

    public BookTransactionService
    (IBookTransactionRepository bookTransactionRepository,
        IUnitOfWork unitOfWork,
        ISharedUserRepository sharedUserRepository,
        ISharedBookManagementRepository sharedBookManagementRepository)
    {
        _bookTransactionRepository = bookTransactionRepository;
        _unitOfWork = unitOfWork;
        _sharedUserRepository = sharedUserRepository;
        _sharedBookManagementRepository = sharedBookManagementRepository;
    }

    public async Task<Order> ReserveBook(Guid bookId, Guid userId, CancellationToken cancellationToken = default)
    {
        if (!await _sharedUserRepository.IsUserExistsUserId(userId))
            throw new NotFoundException("user not found");
        if (!await _sharedBookManagementRepository.IsBookExistsByBookId(bookId))
            throw new NotFoundException("book not found");

        var result = await _bookTransactionRepository.ReserveBook(bookId, userId);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return result;
    }

    public async Task<Order> CheckOutBook(Guid orderId)
    {
        if (!await _sharedBookManagementRepository.IsOrderExistsByOrderId(orderId))
            throw new NotFoundException("order not found");

        return await _bookTransactionRepository.CheckOutBook(orderId);
    }

    public async Task<Order> AcceptReturnedBook(Guid orderId)
    {
        if (!await _sharedBookManagementRepository.IsOrderExistsByOrderId(orderId))
            throw new NotFoundException("order not found");

        return await _bookTransactionRepository.AcceptReturnedBook(orderId);
    }

    public async Task<Order> RejectReserveBook(Guid orderId, CancellationToken cancellationToken = default)
    {
        if (!await _sharedBookManagementRepository.IsOrderExistsByOrderId(orderId))
            throw new NotFoundException("order not found");

        var order = await _bookTransactionRepository.RejectReserveBook(orderId);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return order;
    }

    public async Task<List<Order>> GetOverdueBooks()
    {
        return await _bookTransactionRepository.GetOverdueBooks();
    }
}