using Application.Cashing;
using Application.Query.ReadingListQuery;
using Domain.DTOs.ReadingListDTOs;
using Domain.Services.ReadingListService;

namespace Application.Handler.ReadingListHandler.GetAllReadingListQueryHandler;

public sealed class GetAllReadingListQueryHandler : IGetAllReadingListQueryHandler
{
    private readonly IReadingListService _readingListService;
    private readonly ICashService _cashService;

    public GetAllReadingListQueryHandler(IReadingListService readingListService,
        ICashService cashService)
    {
        _readingListService = readingListService;
        _cashService = cashService;
    }
    public async Task<List<ReadingListResponse>> Handel(GetAllReadingListQuery query)
    {
        var key = $"{query.UserId} ReadingList";
        return await _cashService.GetAsync<List<ReadingListResponse>>
        (key, async () =>
        {
            var readingList = await _readingListService.GetAllReadingList(query.UserId);
            return readingList;
        });
    }
}