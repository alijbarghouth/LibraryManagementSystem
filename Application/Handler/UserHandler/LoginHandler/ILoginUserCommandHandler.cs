using Application.Command.UserCommand;
using Domain.DTOs.UserDTOs;

namespace Application.Handler.UserHandler.LoginHandler;

public interface ILoginUserCommandHandler
{
    Task<LoginUserResponse> Handle(LoginUserCommand login, CancellationToken cancellationToken = default);
}
