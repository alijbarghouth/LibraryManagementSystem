using Application.Command.UserCommand;

namespace Application.Handler.UserHandler.RoleHandler;

public interface IRoleCommandHandler
{
    Task<bool> Handel(AddRoleCommand role);
}
