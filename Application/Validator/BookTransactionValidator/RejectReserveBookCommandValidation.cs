using Application.Command.BookTransactionCommand;
using FluentValidation;

namespace Application.Validator.BookTransactionValidator;

public sealed class RejectReserveBookCommandValidation : AbstractValidator<RejectReserveBookCommand>
{
    public RejectReserveBookCommandValidation()
    {
        RuleFor(x => x.OrderId)
            .NotEmpty().WithMessage("OrderId is required.");
    }
}