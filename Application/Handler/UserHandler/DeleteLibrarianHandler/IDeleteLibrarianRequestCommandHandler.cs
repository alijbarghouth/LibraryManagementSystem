using Application.Command.UserCommand;

namespace Application.Handler.UserHandler.DeleteLibrarianHandler;

public interface IDeleteLibrarianRequestCommandHandler
{
    Task<bool> Handel(DeleteLibrarianRequestCommand command);
}