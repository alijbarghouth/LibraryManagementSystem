namespace Application.Command.BookTransactionCommand;

public record CheckOutBookCommand
(
    Guid OrderId
);