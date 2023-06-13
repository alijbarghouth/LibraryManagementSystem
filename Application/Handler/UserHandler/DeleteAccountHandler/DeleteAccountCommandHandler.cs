using Application.Cashing;
using Application.Command.UserCommand;
using Domain.Services.UserService.AuthService;

namespace Application.Handler.UserHandler.DeleteAccountHandler;

public sealed class DeleteAccountCommandHandler : IDeleteAccountCommandHandler
{
    private readonly IAuthService _authService;
    private readonly ICashService _cashService;

    public DeleteAccountCommandHandler
        (IAuthService authService, ICashService cashService)
    {
        _authService = authService;
        _cashService = cashService;
    }

    public async Task Handel(DeleteAccountCommand command)
    {
        await _authService.DeleteAccount(command.UserId);
        await _cashService.RemoveAsync(command.UserId.ToString());
    }
}