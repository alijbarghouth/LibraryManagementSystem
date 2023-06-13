using Domain.DTOs.UserDTOs;
using Domain.Repositories.SharedRepositories;
using Domain.Repositories.UserRepositories;
using Domain.Shared.Exceptions;
using Domain.Shared.Exceptions.CustomException;

namespace Domain.Services.UserService.LoginService;

public sealed class LoginService : ILoginService
{
    private readonly ILoginRepository _loginRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISharedUserRepository _sharedUserRepository;

    public LoginService(ILoginRepository loginRepository
        , IUnitOfWork unitOfWork,
        ISharedUserRepository sharedUserRepository)
    {
        _loginRepository = loginRepository;
        _unitOfWork = unitOfWork;
        _sharedUserRepository = sharedUserRepository;
    }

    public async Task<(string, string)> LoginUser(LoginUser login,
        CancellationToken cancellationToken = default)
    {
        var tokens = await _loginRepository.LoginUser(login);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return tokens;
    }

    public async Task<(string, string)> RefreshToken(string token, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(token))
            throw new NotFoundException("token not found");
        var tokens = await _loginRepository.RefreshToken(token);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return tokens;
    }

    public async Task<string> GetUserId(LoginUser loginUser)
    {
        if(!await _sharedUserRepository.IsUserExistsByEmail(loginUser.Email))
            throw new NotFoundException("user not found");
        if (!await _sharedUserRepository.IsUserActive(loginUser.Email))
            throw new BadRequestException("account is disable");

        return await _loginRepository.GetUserId(loginUser);
    }

    public async Task ConfirmedEmail(Guid userId, CancellationToken cancellationToken = default)
    {
        if (!await _sharedUserRepository.IsUserExistsUserId(userId))
            throw new NotFoundException("user not found");

        await _loginRepository.ConfirmedEmail(userId);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}