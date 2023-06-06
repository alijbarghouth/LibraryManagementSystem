using Application.Command.InteractionCommand;
using Domain.Services.InteractionService;

namespace Application.Handler.InteractionHandler.DeleteInteractionCommandHandler;

public sealed class DeleteInteractionCommandHandler : IDeleteInteractionCommandHandler
{
    private readonly IInteractionService _interactionService;

    public DeleteInteractionCommandHandler(IInteractionService interactionService)
    {
        _interactionService = interactionService;
    }

    public async Task<bool> Handel(DeleteInteractionCommand command)
    {
        return await _interactionService.DeleteInteraction(command.InteractionId);
    }
}