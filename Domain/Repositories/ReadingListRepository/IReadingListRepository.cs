using Domain.DTOs.ReadingListDTOs;
using Domain.DTOs.Response;

namespace Domain.Repositories.ReadingListRepository;

public interface IReadingListRepository
{
    Task<Response<ReadingList>> AddReadingList(ReadingList readingList);
    Task<bool> DeleteReadingList(Guid readingListId);

    Task<Response<ReadingList>> UpdateReadingList
        (Guid readingListId, ReadingList readingList);

    Task<List<ReadingListResponse>> GetAllReadingList(Guid userId);
}