namespace Application.Command.InteractionCommand;

public record DeleteInteractionCommand
(
    Guid BookReviewId,
    Guid InteractionId
);