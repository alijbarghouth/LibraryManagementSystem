
namespace Application.Handler.UserHandler.ConfirmedEmailHandler;

public interface IConfirmedEmailCommandHandler
{
    Task Handel(Guid userId);
}