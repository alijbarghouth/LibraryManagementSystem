using Domain.DTOs.UserDTOs;

namespace Domain.Repositories.UserRepositories;

public interface IAuthRepository
{
    Task AddRole(RoleRequest role);
}
