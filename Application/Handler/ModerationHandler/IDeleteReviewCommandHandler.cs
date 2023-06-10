using Application.Command.ModerationCommand;

namespace Application.Handler.ModerationHandler;

public interface IDeleteReviewCommandHandler
{
    Task<bool> Handel(DeleteReviewCommand command);
}