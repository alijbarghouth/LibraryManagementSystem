using Domain.DTOs.InteractionDTOs;

namespace Application.Command.InteractionCommand;

public record UpdateInteractionCommand
(
    Interaction Interaction,
    Guid InteractionId  
);