using Application.Cashing;
using Application.Command.ModerationCommand;
using Domain.Services.ModerationService;

namespace Application.Handler.ModerationHandler;

public class DeleteReviewCommandHandler : IDeleteReviewCommandHandler
{
    private readonly IModerationService _moderationService;
    private readonly ICashService _cashService;

    public DeleteReviewCommandHandler(IModerationService moderationService,
        ICashService cashService)
    {
        _moderationService = moderationService;
        _cashService = cashService;
    }

    public async Task<bool> Handel(DeleteReviewCommand command)
    {
        var key = $"BookReview {command.BookId}";
        var result =  await _moderationService.DeleteReview(command.Massage, command.BookReviewId);
        await _cashService.RemoveAsync(key);
        return result;
    }
}