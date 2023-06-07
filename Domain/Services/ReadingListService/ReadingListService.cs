using Domain.DTOs.ReadingListDTOs;
using Domain.DTOs.Response;
using Domain.Repositories.ReadingListRepository;
using Domain.Repositories.SharedRepositories;
using Domain.Shared.Exceptions;
using Domain.Shared.Exceptions.CustomException;

namespace Domain.Services.ReadingListService;

public sealed class ReadingListService : IReadingListService
{
    private readonly IReadingListRepository _readingListRepository;
    private readonly ISharedBookManagementRepository _sharedBookManagementRepository;
    private readonly ISharedUserRepository _sharedUserRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ReadingListService(IReadingListRepository readingListRepository,
        ISharedBookManagementRepository sharedBookManagementRepository,
        ISharedUserRepository sharedUserRepository,
        IUnitOfWork unitOfWork)
    {
        _readingListRepository = readingListRepository;
        _sharedBookManagementRepository = sharedBookManagementRepository;
        _sharedUserRepository = sharedUserRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Response<ReadingList>> AddReadingList
        (ReadingList readingList, CancellationToken cancellationToken = default)
    {
        if (!await _sharedUserRepository.IsUserExistsUserId(readingList.UserId))
            throw new NotFoundException("book not found");
        if (!await _sharedBookManagementRepository.IsBookExistsByBookId(readingList.BookId))
            throw new NotFoundException("book not found");
        if (await _sharedBookManagementRepository.IsReadingListExistsByBookIdAndUserId(readingList.UserId,readingList.BookId))
            throw new BadRequestException("book is exists in readingList");

        var readList = await _readingListRepository.AddReadingList(readingList);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return readList;
    }

    public async Task<bool> DeleteReadingList(Guid readingListId, CancellationToken cancellationToken = default)
    {
        if (!await _sharedBookManagementRepository.IsReadingListExistsByAuthorId(readingListId))
            throw new NotFoundException("readingList not found");
        var result = await _readingListRepository.DeleteReadingList(readingListId);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return result;
    }
    public async Task<List<ReadingListResponse>> GetAllReadingList(Guid userId)
    {
        return await _readingListRepository.GetAllReadingList(userId);
    }
}