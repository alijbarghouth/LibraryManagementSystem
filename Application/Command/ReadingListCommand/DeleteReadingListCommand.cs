namespace Application.Command.ReadingListCommand;

public record DeleteReadingListCommand
(
    Guid UserId,
    Guid ReadingListId
);