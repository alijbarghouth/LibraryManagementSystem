namespace Application.Command.BookTransactionCommand;

public record AcceptReturnedBookCommand
(
    Guid OrderId
);