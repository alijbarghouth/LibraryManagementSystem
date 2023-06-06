using Application.Command.BookTransactionCommand;
using FluentValidation;

namespace Application.Validator.BookTransactionValidator;

public sealed class AcceptReturnedBookCommandValidation : AbstractValidator<AcceptReturnedBookCommand>
{
    public AcceptReturnedBookCommandValidation()
    {
        RuleFor(x => x.OrderId)
            .NotEmpty().WithMessage("OrderId is required.");
    }
}