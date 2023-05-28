using Domain.Features.UserService.DTOs;
using FluentValidation;

namespace Application.Features.UserFeature.Validator;

public sealed class UserValidation : AbstractValidator<User>
{
    public UserValidation()
    {
        RuleFor(x => x.Password)
             .NotEmpty().WithMessage("Password is required.")
             .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$")
             .WithMessage("Password must contain at least one uppercase letter, one lowercase letter, one digit, and one special character, and be at least 8 characters long.");
        
        RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Username is required.")
                .Matches(@"^[^\s.]+$")
                .WithMessage("Username cannot contain spaces or dots.");
       
        RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress();
        
        RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("FirstName is required.");
        
        RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("LastName is required.");

    }
}
