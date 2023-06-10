using Application.Cashing;
using Application.Command.ReadingListCommand;
using Domain.DTOs.ReadingListDTOs;
using Domain.DTOs.Response;
using Domain.Services.ReadingListService;

namespace Application.Handler.ReadingListHandler.AddReadingListHandler;

public sealed class AddReadingListCommandHandler : IAddReadingListCommandHandler
{
    private readonly IReadingListService _readingListService;
    private readonly ICashService _cashService;

    public AddReadingListCommandHandler(IReadingListService readingListService,
        ICashService cashService)
    {
        _readingListService = readingListService;
        _cashService = cashService;
    }

    public async Task<Response<ReadingList>> Handel(AddReadingListCommand command)
    {
        var key = $"{command.ReadingList.UserId} ReadingList";
        var readingList = await _readingListService.AddReadingList(command.ReadingList);
        await _cashService.RemoveAsync(key);
        return readingList;
    }
}