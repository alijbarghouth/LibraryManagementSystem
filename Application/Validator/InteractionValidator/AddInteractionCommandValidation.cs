using Application.Command.InteractionCommand;
using FluentValidation;

namespace Application.Validator.InteractionValidator;

public sealed class AddInteractionCommandValidation : AbstractValidator<AddInteractionCommand>
{
    public AddInteractionCommandValidation()
    {
        RuleFor(x => x.Interaction.Type)
            .NotEmpty().WithMessage("Type is required.");
        RuleFor(x => x.Interaction.UserId)
            .NotEmpty().WithMessage("UserId is required.");
        RuleFor(x => x.Interaction.BookReviewId)
            .NotEmpty().WithMessage("BookReviewId is required.");
    }
}