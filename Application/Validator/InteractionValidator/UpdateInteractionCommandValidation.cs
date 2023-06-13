using Application.Command.InteractionCommand;
using FluentValidation;

namespace Application.Validator.InteractionValidator;

public class UpdateInteractionCommandValidation : AbstractValidator<UpdateInteractionCommand>
{
    public UpdateInteractionCommandValidation()
    {
        RuleFor(x => x.Interaction.Type)
            .NotEmpty().WithMessage("Type is required.");
        RuleFor(x => x.Interaction.UserId)
            .NotEmpty().WithMessage("UserId is required.");
        RuleFor(x => x.Interaction.BookReviewId)
            .NotEmpty().WithMessage("BookReviewId is required.");
        RuleFor(x => x.InteractionId)
            .NotEmpty().WithMessage("InteractionId is required.");
    }
}