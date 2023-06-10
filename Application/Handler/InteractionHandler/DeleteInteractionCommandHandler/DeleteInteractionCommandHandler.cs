using Application.Cashing;
using Application.Command.InteractionCommand;
using Domain.Services.InteractionService;

namespace Application.Handler.InteractionHandler.DeleteInteractionCommandHandler;

public sealed class DeleteInteractionCommandHandler : IDeleteInteractionCommandHandler
{
    private readonly IInteractionService _interactionService;
    private readonly ICashService _cashService;

    public DeleteInteractionCommandHandler(IInteractionService interactionService,
        ICashService cashService)
    {
        _interactionService = interactionService;
        _cashService = cashService;
    }

    public async Task<bool> Handel(DeleteInteractionCommand command)
    {
        var key = command.BookReviewId.ToString();
        var result =  await _interactionService.DeleteInteraction(command.InteractionId);
        await _cashService.RemoveAsync(key);
        return result;
    }
}