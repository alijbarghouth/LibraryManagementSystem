namespace Domain.DTOs.BookReviewDTOs;

public record UpdateBookReviewequest
(
    int Rating,
    string Content
);