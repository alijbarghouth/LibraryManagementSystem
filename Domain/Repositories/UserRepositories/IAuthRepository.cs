using Domain.DTOs.UserDTOs;

namespace Domain.Repositories.UserRepositories;

public interface IAuthRepository
{
    Task AddRole(RoleRequest role);

    Task<UpdateLibrarianRequest> UpdateLibrarianAccount(Guid userId
        , UpdateLibrarianRequest updateLibrarianRequest);

    Task<bool> DeleteLibrarianAccount(Guid userId);
}