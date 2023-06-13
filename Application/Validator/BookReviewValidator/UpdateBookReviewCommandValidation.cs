using Application.Command.BookReviewCommand;
using FluentValidation;

namespace Application.Validator.BookReviewValidator;

public class UpdateBookReviewCommandValidation : AbstractValidator<UpdateBookReviewCommand>
{
    public UpdateBookReviewCommandValidation()
    {
        RuleFor(x => x.BookReview.Content)
            .NotEmpty().WithMessage("Content is required.");
        RuleFor(x => x.BookReview.Rating)
            .NotEmpty().WithMessage("Rating is required.");
        RuleFor(x => x.BookReviewId)
            .NotEmpty().WithMessage("BookReviewId is required.");
    }
}