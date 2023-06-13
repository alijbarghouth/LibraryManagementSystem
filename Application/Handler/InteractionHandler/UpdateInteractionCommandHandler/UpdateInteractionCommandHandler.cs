using Application.Cashing;
using Application.Command.InteractionCommand;
using Domain.DTOs.InteractionDTOs;
using Domain.DTOs.Response;
using Domain.Services.InteractionService;

namespace Application.Handler.InteractionHandler.UpdateInteractionCommandHandler;

public sealed class UpdateInteractionCommandHandler : IUpdateInteractionCommandHandler
{
    private readonly IInteractionService _interactionService;
    private readonly ICashService _cashService;

    public UpdateInteractionCommandHandler(IInteractionService interactionService,
        ICashService cashService)
    {
        _interactionService = interactionService;
        _cashService = cashService;
    }

    public async Task<Response<Interaction>> Handel(UpdateInteractionCommand command)
    {
        var key = command.Interaction.BookReviewId.ToString();
        var interaction =  await _interactionService.UpdateInteraction(command.Interaction, command.InteractionId);
        await _cashService.RemoveAsync(key);
        return interaction;
    }
}