using Domain.DTOs.UserDTOs;

namespace Domain.Services.Services.AuthService;

public interface IAuthService
{
    Task<bool> AddRole(RoleRequest role, CancellationToken cancellationToken = default);
}
