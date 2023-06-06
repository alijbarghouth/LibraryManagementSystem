using Application.Query.BookReview;
using FluentValidation;

namespace Application.Validator.BookReviewValidator;

public sealed class GetAllBookReviewQueryValidation : AbstractValidator<GetAllBookReviewQuery>
{
    public GetAllBookReviewQueryValidation()
    {
        RuleFor(x => x.BookId)
            .NotEmpty().WithMessage("BookId is required.");
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("UserId is required.");
    }
}