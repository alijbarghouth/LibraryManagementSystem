using Application.Command.ReadingListCommand;
using Domain.Services.ReadingListService;

namespace Application.Handler.ReadingListHandler.DeleteReadingListHandler;

public class DeleteReadingListCommandHandler : IDeleteReadingListCommandHandler
{
    private readonly IReadingListService _readingListService;

    public DeleteReadingListCommandHandler(IReadingListService readingListService)
    {
        _readingListService = readingListService;
    }

    public async Task<bool> Handel(DeleteReadingListCommand command)
    {
        return await _readingListService.DeleteReadingList(command.ReadingListId);
    }
}