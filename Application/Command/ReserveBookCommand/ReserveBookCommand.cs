namespace Application.Command.ReserveBookCommand;

public record ReserveBookCommand(Guid BookId, Guid UserId);
