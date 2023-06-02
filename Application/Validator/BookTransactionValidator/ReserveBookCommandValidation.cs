using Application.Command.BookTransactionCommand;
using FluentValidation;

namespace Application.Validator.BookTransactionValidator;

public class ReserveBookCommandValidation : AbstractValidator<ReserveBookCommand>
{
    public ReserveBookCommandValidation()
    {
        RuleFor(x => x.BookId)
            .NotEmpty().WithMessage("BookId is required.");
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("UserId is required.");
    }
}