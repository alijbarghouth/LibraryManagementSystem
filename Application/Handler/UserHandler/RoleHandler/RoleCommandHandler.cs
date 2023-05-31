using Application.Command.UserCommand;
using Domain.Services.Services.AuthService;

namespace Application.Handler.UserHandler.RoleHandler;

public sealed class RoleCommandHandler : IRoleCommandHandler
{
    private readonly IAuthService _authService;

    public RoleCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<bool> Handel(AddRoleCommand role)
    {
        return await _authService.AddRole(role.RoleRequest);
    }
}
