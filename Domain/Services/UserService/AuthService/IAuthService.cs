using Domain.DTOs.UserDTOs;

namespace Domain.Services.UserService.AuthService;

public interface IAuthService
{
    Task<bool> AddRole(RoleRequest role, CancellationToken cancellationToken = default);

    Task<UpdateLibrarianRequest> UpdateLibrarianAccount
        (Guid userId, UpdateLibrarianRequest updateLibrarianRequest);

    Task<bool> DeleteLibrarianAccount(Guid userId, CancellationToken cancellationToken = default);
    Task ResetPassword(ResetPassword resetPassword, CancellationToken cancellationToken = default);
    Task DeleteAccount(Guid userId, CancellationToken cancellationToken = default);
}