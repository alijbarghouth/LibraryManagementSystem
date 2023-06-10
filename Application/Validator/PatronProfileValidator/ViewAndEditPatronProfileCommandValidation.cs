using Application.Command.PatronProfileCommand;
using FluentValidation;

namespace Application.Validator.PatronProfileValidator;

public sealed class ViewAndEditPatronProfileCommandValidation : AbstractValidator<ViewAndEditPatronProfileCommand>
{
    public ViewAndEditPatronProfileCommandValidation()
    {
        RuleFor(x => x.PatronProfile.Id)
            .NotEmpty().WithMessage("id is required.");
        RuleFor(x => x.PatronProfile.UserId)
            .NotEmpty().WithMessage("userId is required.");
        RuleFor(x => x.PatronProfile.OrderDate)
            .NotEmpty().WithMessage("orderDate is required.");
        RuleFor(x => x.PatronProfile.StatusRequest)
            .NotEmpty().WithMessage("StatusRequest is required.");
        RuleFor(x => x.PatronProfile.OrderItems)
            .NotEmpty().WithMessage("OrderItems is required.");
        RuleFor(x => x.OrderId)
            .NotEmpty().WithMessage("OrderId is required.");
    }
}