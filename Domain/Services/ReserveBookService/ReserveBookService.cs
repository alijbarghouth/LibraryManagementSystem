using Domain.Repositories.ReserveBookRepository;
using Domain.Shared.Exceptions;

namespace Domain.Services.ReserveBookService;

public sealed class ReserveBookService : IReserveBookService
{
    private readonly IReserveBookRepository _reserveBookRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ReserveBookService(IReserveBookRepository reserveBookRepository, IUnitOfWork unitOfWork)
    {
        _reserveBookRepository = reserveBookRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> ReserveBook(Guid bookId, Guid userId, CancellationToken cancellationToken = default)
    {
        var result = await _reserveBookRepository.ReserveBook(bookId, userId);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return result;
    }
}
