using Domain.DTOs.BookReviewDTOs;

namespace Application.Command.BookReviewCommand;

public record AddBookReviewCommand
(
    BookReview BookReview
);