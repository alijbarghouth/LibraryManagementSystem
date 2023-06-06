using Application.Command.InteractionCommand;
using Domain.DTOs.InteractionDTOs;
using Domain.DTOs.Response;
using Domain.Services.InteractionService;

namespace Application.Handler.InteractionHandler.UpdateInteractionCommandHandler;

public sealed class UpdateInteractionCommandHandler : IUpdateInteractionCommandHandler
{
    private readonly IInteractionService _interactionService;

    public UpdateInteractionCommandHandler(IInteractionService interactionService)
    {
        _interactionService = interactionService;
    }

    public async Task<Response<Interaction>> Handel(UpdateInteractionCommand command)
    {
        return await _interactionService.UpdateInteraction(command.Interaction, command.InteractionId);
    }
}