using Application.Command.BookTransactionCommand;

namespace Application.Handler.BookTransactionHandler.AcceptReturnedBook;

public interface IAcceptReturnedBookCommandHandler
{
    Task<string> Handel(AcceptReturnedBookCommand command);
}