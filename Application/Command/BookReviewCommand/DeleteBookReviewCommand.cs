namespace Application.Command.BookReviewCommand;

public record DeleteBookReviewCommand
(
    Guid BookId,
    Guid BookReviewId
);