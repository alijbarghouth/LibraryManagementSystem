using Application.Command.UserCommand;

namespace Application.Handler.UserHandler.DeleteAccountHandler;

public interface IDeleteAccountCommandHandler
{
    Task Handel(DeleteAccountCommand command);
}