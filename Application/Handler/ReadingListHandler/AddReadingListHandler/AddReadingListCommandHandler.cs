using Application.Command.ReadingListCommand;
using Domain.DTOs.ReadingListDTOs;
using Domain.DTOs.Response;
using Domain.Services.ReadingListService;

namespace Application.Handler.ReadingListHandler.AddReadingListHandler;

public class AddReadingListCommandHandler : IAddReadingListCommandHandler
{
    private readonly IReadingListService _readingListService;

    public AddReadingListCommandHandler(IReadingListService readingListService)
    {
        _readingListService = readingListService;
    }

    public async Task<Response<ReadingList>> Handel(AddReadingListCommand command)
    {
        return await _readingListService.AddReadingList(command.ReadingList);
    }
}