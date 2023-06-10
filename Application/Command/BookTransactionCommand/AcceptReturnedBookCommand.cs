namespace Application.Command.BookTransactionCommand;

public record AcceptReturnedBookCommand
(
    Guid UserId,
    Guid OrderId
);