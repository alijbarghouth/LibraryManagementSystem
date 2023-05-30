using Application.Features.UserFeature.Command;
using Domain.Features.UserService.Services.AuthService;

namespace Application.Features.UserFeature.Handler.RoleHandler;

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
