using Domain.DTOs.BookReviewDTOs;

namespace Application.Command.BookReviewCommand;

public record UpdateBookReviewCommand
(
    Guid BookReviewId,
    UpdateBookReviewequest BookReview   
);