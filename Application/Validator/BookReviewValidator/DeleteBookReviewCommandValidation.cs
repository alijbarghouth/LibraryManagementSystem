using Application.Command.BookReviewCommand;
using FluentValidation;

namespace Application.Validator.BookReviewValidator;

public class DeleteBookReviewCommandValidation : AbstractValidator<DeleteBookReviewCommand>
{
    public DeleteBookReviewCommandValidation()
    {
        RuleFor(x => x.BookReviewId)
            .NotEmpty().WithMessage("BookReviewId is required.");
    }
}