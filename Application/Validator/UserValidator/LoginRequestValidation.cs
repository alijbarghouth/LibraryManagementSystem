using Application.Command.UserCommand;
using Domain.DTOs.UserDTOs;
using FluentValidation;

namespace Application.Validator.UserValidator;

public sealed class LoginRequestValidation : AbstractValidator<LoginUserCommand>
{
    public LoginRequestValidation()
    {
        RuleFor(x => x.LoginUser.Password)
            .NotEmpty().WithMessage("Password is required.")
            .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$")
            .WithMessage(
                "Password must contain at least one uppercase letter, one lowercase letter, one digit, and one special character, and be at least 8 characters long.");

        RuleFor(x => x.LoginUser.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress();
    }
}