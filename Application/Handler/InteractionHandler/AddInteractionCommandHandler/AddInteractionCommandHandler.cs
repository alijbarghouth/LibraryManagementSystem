using Application.Cashing;
using Application.Command.InteractionCommand;
using Domain.DTOs.InteractionDTOs;
using Domain.DTOs.Response;
using Domain.Services.InteractionService;

namespace Application.Handler.InteractionHandler.AddInteractionCommandHandler;

public sealed class AddInteractionCommandHandler : IAddInteractionCommandHandler
{
    private readonly IInteractionService _interactionService;
    private readonly ICashService _cashService;
    public AddInteractionCommandHandler(IInteractionService interactionService,
        ICashService cashService)
    {
        _interactionService = interactionService;
        _cashService = cashService;
    }

    public async Task<Response<Interaction>> Handel(AddInteractionCommand command)
    {
        var key = command.Interaction.BookReviewId.ToString();
        var interaction =  await _interactionService.AddInteraction(command.Interaction);
        await _cashService.RemoveAsync(key);
        return interaction;
    }
}