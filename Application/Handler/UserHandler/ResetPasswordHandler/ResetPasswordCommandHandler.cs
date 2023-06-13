using Application.Command.UserCommand;
using Domain.Services.UserService.AuthService;

namespace Application.Handler.UserHandler.ResetPasswordHandler;

public sealed class ResetPasswordCommandHandler : IResetPasswordCommandHandler
{
    private readonly IAuthService _authService;

    public ResetPasswordCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<bool> Handel(ResetPasswordCommand command)
    {
        await _authService.ResetPassword(command.ResetPassword);
        return true;
    }
}