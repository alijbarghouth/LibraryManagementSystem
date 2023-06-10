using Application.Command.UserCommand;
using Domain.DTOs.UserDTOs;

namespace Application.Handler.UserHandler.UpdateLibrarianHandler;

public interface IUpdateLibrarianRequestCommandHandler
{
    Task<UpdateLibrarianRequest> Handel
        (UpdateLibrarianRequestCommand command, CancellationToken cancellationToken = default);
}