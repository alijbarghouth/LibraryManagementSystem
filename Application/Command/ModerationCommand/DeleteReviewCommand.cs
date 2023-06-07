namespace Application.Command.ModerationCommand;

public record DeleteReviewCommand
(
    string Massage,
    Guid BookReviewId,
    Guid BookId
);