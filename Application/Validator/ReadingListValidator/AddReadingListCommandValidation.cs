using Application.Command.ReadingListCommand;
using FluentValidation;

namespace Application.Validator.ReadingListValidator;

public class AddReadingListCommandValidation : AbstractValidator<AddReadingListCommand>
{
    public AddReadingListCommandValidation()
    {
        RuleFor(x => x.ReadingList.BookId)
            .NotEmpty().WithMessage("BookId is required.");
        RuleFor(x => x.ReadingList.UserId)
            .NotEmpty().WithMessage("UserId is required.");
    }
}