using Application.Command.AuthorCommand;
using FluentValidation;

namespace Application.Validator.AuthorBookValidator;

public sealed class AuthorValidation : AbstractValidator<AddAuthorCommand>
{
    public AuthorValidation()
    {
        RuleFor(x => x.Author.FirstName)
             .NotEmpty().WithMessage("FirstName is required.");
        RuleFor(x => x.Author.LastName)
             .NotEmpty().WithMessage("LastName is required.");
        RuleFor(x => x.Author.Username)
                .NotEmpty().WithMessage("Username is required.")
                .Matches(@"^[^\s.]+$")
                .WithMessage("Username cannot contain spaces or dots.");
    }
}
