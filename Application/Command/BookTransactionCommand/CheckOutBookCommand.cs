namespace Application.Command.BookTransactionCommand;

public record CheckOutBookCommand
(
    Guid UserId,
    Guid OrderId
);