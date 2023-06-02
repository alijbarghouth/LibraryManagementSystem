using Application.Command.BookTransactionCommand;
using FluentValidation;

namespace Application.Validator.BookTransactionValidator;

public class CheckOutBookCommandValidation : AbstractValidator<CheckOutBookCommand>
{
    public CheckOutBookCommandValidation()
    {
        RuleFor(x => x.OrderId)
            .NotEmpty().WithMessage("OrderId is required.");
    }
}