namespace Application.Command.BookTransactionCommand;

public record RejectReserveBookCommand
(
    Guid OrderId
);