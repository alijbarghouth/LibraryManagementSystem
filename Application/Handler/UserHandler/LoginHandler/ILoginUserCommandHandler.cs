using Application.Command.UserCommand;

namespace Application.Handler.UserHandler.LoginHandler;

public interface ILoginUserCommandHandler
{
    Task<(string, string)> Handle(LoginUserCommand login);
}
