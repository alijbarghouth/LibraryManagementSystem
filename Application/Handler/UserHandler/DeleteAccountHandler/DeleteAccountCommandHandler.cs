using Application.Command.UserCommand;
using Domain.Services.UserService.AuthService;

namespace Application.Handler.UserHandler.DeleteAccountHandler;

public sealed class DeleteAccountCommandHandler : IDeleteAccountCommandHandler
{
    private readonly IAuthService _authService;

    public DeleteAccountCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task Handel(DeleteAccountCommand command)
    {
        await _authService.DeleteAccount(command.UserId);
    }
}