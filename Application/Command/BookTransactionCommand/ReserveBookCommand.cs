namespace Application.Command.BookTransactionCommand;

public record ReserveBookCommand(Guid BookId, Guid UserId);
