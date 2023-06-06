namespace Application.Query.BookReview;

public record GetAllBookReviewQuery
(
    Guid UserId,
    Guid BookId
);