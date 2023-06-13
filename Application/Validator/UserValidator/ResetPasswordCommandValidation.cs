using Application.Command.UserCommand;
using FluentValidation;

namespace Application.Validator.UserValidator;

public sealed class ResetPasswordCommandValidation : AbstractValidator<ResetPasswordCommand>
{
    public ResetPasswordCommandValidation()
    {
        RuleFor(x => x.ResetPassword.CurrentPassword)
            .NotEmpty().WithMessage("Password is required.")
            .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$")
            .WithMessage(
                "Password must contain at least one uppercase letter, one lowercase letter, one digit, and one special character, and be at least 8 characters long.");
        RuleFor(x => x.ResetPassword.NewPassword)
            .NotEmpty().WithMessage("Password is required.")
            .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$")
            .WithMessage(
                "Password must contain at least one uppercase letter, one lowercase letter, one digit, and one special character, and be at least 8 characters long.");
        RuleFor(x => x.ResetPassword.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress();
    }
}