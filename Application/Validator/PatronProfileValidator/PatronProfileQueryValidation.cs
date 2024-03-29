using Application.Query.PatronProfile;
using FluentValidation;

namespace Application.Validator.PatronProfileValidator;

public sealed class PatronProfileQueryValidation : AbstractValidator<PatronProfileQuery>
{
    public PatronProfileQueryValidation()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("id is required.");
    }
}