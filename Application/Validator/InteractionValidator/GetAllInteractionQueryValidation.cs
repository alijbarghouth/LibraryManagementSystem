using Application.Query.InteractionQuery;
using FluentValidation;

namespace Application.Validator.InteractionValidator;

public class GetAllInteractionQueryValidation : AbstractValidator<GetAllInteractionQuery>
{
    public GetAllInteractionQueryValidation()
    {
        RuleFor(x => x.BookReviewId)
            .NotEmpty().WithMessage("BookReviewId is required.");
    }
}