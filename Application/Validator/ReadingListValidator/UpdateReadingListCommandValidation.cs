using Application.Command.ReadingListCommand;
using FluentValidation;

namespace Application.Validator.ReadingListValidator;

public sealed class UpdateReadingListCommandValidation : AbstractValidator<UpdateReadingListCommand>
{
    public UpdateReadingListCommandValidation()
    {
        RuleFor(x => x.ReadingListId)
            .NotEmpty().WithMessage("ReadingListId is required.");
        RuleFor(x => x.ReadingList.BookId)
            .NotEmpty().WithMessage("BookId is required.");
        RuleFor(x => x.ReadingList.UserId)
            .NotEmpty().WithMessage("UserId is required.");
    }
}