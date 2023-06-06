using Application.Command.InteractionCommand;
using Domain.DTOs.InteractionDTOs;
using Domain.DTOs.Response;
using Domain.Services.InteractionService;

namespace Application.Handler.InteractionHandler.AddInteractionCommandHandler;

public sealed class AddInteractionCommandHandler : IAddInteractionCommandHandler
{
    private readonly IInteractionService _interactionService;

    public AddInteractionCommandHandler(IInteractionService interactionService)
    {
        _interactionService = interactionService;
    }

    public async Task<Response<Interaction>> Handel(AddInteractionCommand command)
    {
        return await _interactionService.AddInteraction(command.Interaction);
    }
}