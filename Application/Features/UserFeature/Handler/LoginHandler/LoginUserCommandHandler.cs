using Application.Features.UserFeature.Command;
using Domain.Features.UserService.Services.LoginService;

namespace Application.Features.UserFeature.Handler.LoginHandler;

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
