using Application.Query.ReadingListQuery;
using Domain.DTOs.ReadingListDTOs;

namespace Application.Handler.ReadingListHandler.GetAllReadingListQueryHandler;

public interface IGetAllReadingListQueryHandler
{
    Task<List<ReadingListResponse>> Handel(GetAllReadingListQuery query);
}