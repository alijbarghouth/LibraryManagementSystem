using Application.Cashing;
using Application.Command.UserCommand;
using Domain.Services.UserService.AuthService;

namespace Application.Handler.UserHandler.RoleHandler;

public sealed class RoleCommandHandler : IRoleCommandHandler
{
    private readonly IAuthService _authService;
    private readonly ICashService _cashService;

    public RoleCommandHandler(IAuthService authService,
        ICashService cashService)
    {
        _authService = authService;
        _cashService = cashService;
    }

    public async Task<bool> Handel(AddRoleCommand role)
    {
        var result = await _authService.AddRole(role.RoleRequest);
        await _cashService.RemoveAsync(role.RoleRequest.UserId.ToString());
        return result;
    }
}