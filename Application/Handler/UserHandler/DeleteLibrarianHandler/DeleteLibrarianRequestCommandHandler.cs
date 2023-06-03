using Application.Command.UserCommand;
using Domain.Services.UserService.AuthService;

namespace Application.Handler.UserHandler.DeleteLibrarianHandler;

public class DeleteLibrarianRequestCommandHandler  :IDeleteLibrarianRequestCommandHandler
{
    private readonly IAuthService _authService;

    public DeleteLibrarianRequestCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<bool> Handel(DeleteLibrarianRequestCommand command)
    {
        return await _authService.DeleteLibrarianAccount(command.UserId);
    }
}