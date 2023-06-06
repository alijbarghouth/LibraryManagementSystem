using Application.Command.InteractionCommand;
using FluentValidation;

namespace Application.Validator.InteractionValidator;

public class DeleteInteractionCommandValidation : AbstractValidator<DeleteInteractionCommand>
{
    public DeleteInteractionCommandValidation()
    {
        RuleFor(x => x.InteractionId)
            .NotEmpty().WithMessage("InteractionId is required.");
    }
}