using Application.Command.BookReviewCommand;
using FluentValidation;

namespace Application.Validator.BookReviewValidator;

public sealed class AddBookReviewCommandValidation : AbstractValidator<AddBookReviewCommand>
{
    public AddBookReviewCommandValidation()
    {
        RuleFor(x => x.BookReview.BookId)
            .NotEmpty().WithMessage("BookId is required.");
        RuleFor(x => x.BookReview.Rating)
            .NotEmpty().WithMessage("Rating is required.");
        RuleFor(x => x.BookReview.Content)
            .NotEmpty().WithMessage("Content is required.");
        RuleFor(x => x.BookReview.UserId)
            .NotEmpty().WithMessage("UserId is required.");
    }
}