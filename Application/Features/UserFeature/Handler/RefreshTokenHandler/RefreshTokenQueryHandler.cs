using Domain.Features.UserService.Services.LoginService;

namespace Application.Features.UserFeature.Handler.RefreshTokenHandler;

public sealed class RefreshTokenQueryHandler : IRefreshTokenQueryHandler
{
    private readonly ILoginService _loginService;

    public RefreshTokenQueryHandler(ILoginService loginService)
    {
        _loginService = loginService;
    }

    public async Task<(string, string)> RefreshToken(string token)
    {
        return await _loginService.RefreshToken(token);
    }
}
