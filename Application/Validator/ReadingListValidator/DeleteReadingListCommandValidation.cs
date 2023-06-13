using Application.Command.ReadingListCommand;
using FluentValidation;

namespace Application.Validator.ReadingListValidator;

public sealed class DeleteReadingListCommandValidation : AbstractValidator<DeleteReadingListCommand>
{
    public DeleteReadingListCommandValidation()
    {
        RuleFor(x => x.ReadingListId)
            .NotEmpty().WithMessage("ReadingListId is required.");
    }
}