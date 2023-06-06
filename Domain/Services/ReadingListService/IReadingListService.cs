using Domain.DTOs.ReadingListDTOs;
using Domain.DTOs.Response;

namespace Domain.Services.ReadingListService;

public interface IReadingListService
{
    Task<Response<ReadingList>> AddReadingList
        (ReadingList readingList, CancellationToken cancellationToken = default);

    Task<bool> DeleteReadingList(Guid readingListId,
        CancellationToken cancellationToken = default);

    Task<Response<ReadingList>> UpdateReadingList
    (Guid readingListId, ReadingList readingList,
        CancellationToken cancellationToken = default);

    Task<List<ReadingListResponse>> GetAllReadingList(Guid userId);
}