using Application.Features.UserFeature.Command;

namespace Application.Features.UserFeature.Handler.RoleHandler;

public interface IRoleCommandHandler
{
    Task<bool> Handel(AddRoleCommand role);
}
