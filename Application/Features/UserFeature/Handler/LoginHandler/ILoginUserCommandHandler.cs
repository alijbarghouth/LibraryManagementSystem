using Application.Features.UserFeature.Command;

namespace Application.Features.UserFeature.Handler.LoginHandler;

public interface ILoginUserCommandHandler
{
    Task<(string, string)> Handle(LoginUserCommand login);
}
