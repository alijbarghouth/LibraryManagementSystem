using Domain.Services.UserService.LoginService;

namespace Application.Handler.UserHandler.ConfirmedEmailHandler;

public class ConfirmedEmailCommandHandler : IConfirmedEmailCommandHandler
{
    private readonly ILoginService _loginService;

    public ConfirmedEmailCommandHandler(ILoginService loginService)
    {
        _loginService = loginService;
    }

    public async Task Handel(Guid userId)
    {
        await _loginService.ConfirmedEmail(userId);
    }
}