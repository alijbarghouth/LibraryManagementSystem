using Application.Cashing;
using Application.Command.UserCommand;
using Domain.DTOs.UserDTOs;
using Domain.Services.UserService.LoginService;

namespace Application.Handler.UserHandler.LoginHandler;

public sealed class LoginUserCommandHandler : ILoginUserCommandHandler
{
    private readonly ILoginService _loginService;
    private readonly ICashService _cashService;

    public LoginUserCommandHandler(ILoginService loginService,
        ICashService cashService)
    {
        _loginService = loginService;
        _cashService = cashService;
    }

    public async Task<LoginUserResponse> Handle(LoginUserCommand login,
        CancellationToken cancellationToken = default)
    {
        var userId = await _loginService.GetUserId(login.LoginUser) ;
        return await _cashService.GetAsync<LoginUserResponse>(userId, async () =>
        {
            var tokens = await _loginService.LoginUser(login.LoginUser, cancellationToken);
            return new LoginUserResponse(tokens.Item1, tokens.Item2);
        },"token", cancellationToken);
    }
}