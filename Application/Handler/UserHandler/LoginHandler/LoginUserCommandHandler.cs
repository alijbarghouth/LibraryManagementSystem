using Application.Command.UserCommand;
using Domain.Services.Services.LoginService;

namespace Application.Handler.UserHandler.LoginHandler;

public sealed class LoginUserCommandHandler : ILoginUserCommandHandler
{
    private readonly ILoginService _loginService;

    public LoginUserCommandHandler(ILoginService loginService)
    {
        _loginService = loginService;
    }

    public async Task<(string, string)> Handle(LoginUserCommand login)
    {
        return await _loginService.LoginUser(login.LoginUser);
    }
}
