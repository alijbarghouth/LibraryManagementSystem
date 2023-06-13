using Application.Command.BookCommand;

namespace Application.Handler.BookHandler.DeleteBookCommandHandler;

public interface IDeleteBookCommandHandler
{
    Task<bool> Handel(DeleteBookCommand command);
}