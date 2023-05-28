using Domain.Features.UserService.DTOs;
using Domain.Shared.Exceptions;
using Domain.Shared.Exceptions.CustomException;

namespace Domain.Features.UserService.Services.AuthService;

public sealed class AuthService : IAuthService
{
    private readonly IAuthRepository _authRepository;
    private readonly IUnitOfWork _unitOfWork;
    public AuthService(IAuthRepository authRepository, IUnitOfWork unitOfWork)
    {
        _authRepository = authRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> AddRole(RoleRequest role, CancellationToken cancellationToken = default)
    {
        if (role is null)
            throw new LibraryNotFoundException("role is not found");
        await _authRepository.AddRole(role);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}
