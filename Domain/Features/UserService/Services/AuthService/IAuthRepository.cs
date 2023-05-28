using Domain.Features.UserService.DTOs;

namespace Domain.Features.UserService.Services.AuthService;

public interface IAuthRepository
{
    Task AddRole(RoleRequest role);
}
