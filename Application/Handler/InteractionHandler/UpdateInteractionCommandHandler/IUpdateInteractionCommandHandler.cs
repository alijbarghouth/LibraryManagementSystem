using Application.Command.InteractionCommand;
using Domain.DTOs.InteractionDTOs;
using Domain.DTOs.Response;

namespace Application.Handler.InteractionHandler.UpdateInteractionCommandHandler;

public interface IUpdateInteractionCommandHandler
{
    Task<Response<Interaction>> Handel(UpdateInteractionCommand command);
}