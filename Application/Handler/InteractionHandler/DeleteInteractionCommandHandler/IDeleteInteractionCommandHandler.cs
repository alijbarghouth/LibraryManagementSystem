using Application.Command.InteractionCommand;

namespace Application.Handler.InteractionHandler.DeleteInteractionCommandHandler;

public interface IDeleteInteractionCommandHandler
{
    Task<bool> Handel(DeleteInteractionCommand command);
}