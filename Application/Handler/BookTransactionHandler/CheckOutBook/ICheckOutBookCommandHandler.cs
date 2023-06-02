using Application.Command.BookTransactionCommand;

namespace Application.Handler.BookTransactionHandler.CheckOutBook;

public interface ICheckOutBookCommandHandler
{
    Task<string> Handel(CheckOutBookCommand command);
}