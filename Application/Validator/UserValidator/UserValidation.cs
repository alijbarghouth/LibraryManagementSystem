using Application.Command.UserCommand;
using FluentValidation;

namespace Application.Validator.UserValidator;

public sealed class UserValidation : AbstractValidator<RegisterUserCommand>
{
    public UserValidation()
    {
        RuleFor(x => x.RegisterUser.Password)
            .NotEmpty().WithMessage("Password is required.")
            .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$")
            .WithMessage(
                "Password must contain at least one uppercase letter, one lowercase letter, one digit, and one special character, and be at least 8 characters long.");

        RuleFor(x => x.RegisterUser.Username)
            .NotEmpty().WithMessage("Username is required.")
            .Matches(@"^[^\s.]+$")
            .WithMessage("Username cannot contain spaces or dots.");

        RuleFor(x => x.RegisterUser.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress();

        RuleFor(x => x.RegisterUser.FirstName)
            .NotEmpty().WithMessage("FirstName is required.");

        RuleFor(x => x.RegisterUser.LastName)
            .NotEmpty().WithMessage("LastName is required.");
    }
}