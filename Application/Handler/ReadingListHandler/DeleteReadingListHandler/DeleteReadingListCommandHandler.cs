using Application.Cashing;
using Application.Command.ReadingListCommand;
using Domain.Services.ReadingListService;

namespace Application.Handler.ReadingListHandler.DeleteReadingListHandler;

public sealed class DeleteReadingListCommandHandler : IDeleteReadingListCommandHandler
{
    private readonly IReadingListService _readingListService;
    private readonly ICashService _cashService;

    public DeleteReadingListCommandHandler(IReadingListService readingListService,
        ICashService cashService)
    {
        _readingListService = readingListService;
        _cashService = cashService;
    }

    public async Task<bool> Handel(DeleteReadingListCommand command)
    {
        var key = $"{command.UserId} ReadingList";
        var result = await _readingListService.DeleteReadingList(command.ReadingListId);
        if (result) await _cashService.RemoveAsync(key);
        return result;
    }
}