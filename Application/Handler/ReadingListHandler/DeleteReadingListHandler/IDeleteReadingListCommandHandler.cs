using Application.Command.ReadingListCommand;

namespace Application.Handler.ReadingListHandler.DeleteReadingListHandler;

public interface IDeleteReadingListCommandHandler
{
    Task<bool> Handel(DeleteReadingListCommand command);
}