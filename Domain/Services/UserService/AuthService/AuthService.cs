using Domain.DTOs.UserDTOs;
using Domain.Repositories.SharedRepositories;
using Domain.Repositories.UserRepositories;
using Domain.Shared.Exceptions;
using Domain.Shared.Exceptions.CustomException;

namespace Domain.Services.UserService.AuthService;

public sealed class AuthService : IAuthService
{
    private readonly IAuthRepository _authRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISharedUserRepository _sharedUserRepository;

    public AuthService(IAuthRepository authRepository,
        IUnitOfWork unitOfWork,
        ISharedUserRepository sharedUserRepository)
    {
        _authRepository = authRepository;
        _unitOfWork = unitOfWork;
        _sharedUserRepository = sharedUserRepository;
    }

    public async Task<bool> AddRole(RoleRequest role,
        CancellationToken cancellationToken = default)
    {
        if (role is null)
            throw new NotFoundException("role is not found");
        if (!await _sharedUserRepository.IsUserExistsUserId(role.UserId))
            throw new NotFoundException("user not found");

        await _authRepository.AddRole(role);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<UpdateLibrarianRequest> UpdateLibrarianAccount
        (Guid userId, UpdateLibrarianRequest updateLibrarianRequest)
    {
        if (!await _sharedUserRepository.IsUserExistsUserId(userId))
            throw new NotFoundException("user not found");
        return await _authRepository.UpdateLibrarianAccount(userId, updateLibrarianRequest);
    }

    public async Task<bool> DeleteLibrarianAccount(Guid userId,
        CancellationToken cancellationToken = default)
    {
        if (!await _sharedUserRepository.IsUserExistsUserId(userId))
            throw new NotFoundException("user not found");
        await _authRepository.DeleteLibrarianAccount(userId);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task ResetPassword
    (ResetPassword resetPassword,
        CancellationToken cancellationToken = default)
    {
        if (!await _sharedUserRepository.IsUserExistsByEmail(resetPassword.Email))
            throw new NotFoundException("user not found");
        await _authRepository.ResetPassword(resetPassword);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}