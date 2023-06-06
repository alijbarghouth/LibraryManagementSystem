using Application.Command.ReadingListCommand;
using Domain.DTOs.ReadingListDTOs;
using Domain.DTOs.Response;
using Domain.Services.ReadingListService;

namespace Application.Handler.ReadingListHandler.UpdateReadingListHandler;

public sealed class UpdateReadingListCommandHandler : IUpdateReadingListCommandHandler
{
    private readonly IReadingListService _readingListService;

    public UpdateReadingListCommandHandler(IReadingListService readingListService)
    {
        _readingListService = readingListService;
    }

    public async Task<Response<ReadingList>> Handel(UpdateReadingListCommand command)
    {
        return await _readingListService.UpdateReadingList(command.ReadingListId, command.ReadingList);
    }
}