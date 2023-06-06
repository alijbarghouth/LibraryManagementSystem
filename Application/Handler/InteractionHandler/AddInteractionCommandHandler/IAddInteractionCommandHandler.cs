using Application.Command.InteractionCommand;
using Domain.DTOs.InteractionDTOs;
using Domain.DTOs.Response;

namespace Application.Handler.InteractionHandler.AddInteractionCommandHandler;

public interface IAddInteractionCommandHandler
{
    Task<Response<Interaction>> Handel(AddInteractionCommand command);
}