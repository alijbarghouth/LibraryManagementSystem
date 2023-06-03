using Application.Command.AuthorCommand;

namespace Application.Handler.AuthorHandler.DeleteAuthorCommandHandler;

public interface IDeleteAuthorCommandHandler
{
    Task<bool> Handel(DeleteAuthorCommand command);
}