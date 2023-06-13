namespace Domain.DTOs.BookReviewDTOs;

public record BookReview
(
    Guid UserId,
    Guid BookId,
    int Rating,
    string Content
);