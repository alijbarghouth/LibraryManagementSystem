using Domain.Features.UserService.DTOs;

namespace Application.Features.UserFeature.Command;

public interface ICommandService
{
    Task<User> RegisterUser(User request);
    Task<(string, string)> LoginUser(LoginRequest request);
    Task<bool> AddRole (RoleRequest request);
}
