using Domain.DTOs.UserDTOs;
using Domain.Repositories.SharedRepositories;
using Domain.Repositories.UserRepositories;
using Domain.Shared.Exceptions;
using Domain.Shared.Exceptions.CustomException;
using System.Threading;

namespace Domain.Services.UserService.LoginService;

public class LoginService : ILoginService
{
    private readonly ISharedUserRepository _sharedUserRepository;
    private readonly ILoginRepository _loginRepository;
    private readonly IUnitOfWork _unitOfWork;
    public LoginService(ISharedUserRepository sharedUserRepository, ILoginRepository loginRepository
        , IUnitOfWork unitOfWork)
    {
        _sharedUserRepository = sharedUserRepository;
        _loginRepository = loginRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<(string, string)> LoginUser(LoginUser login, CancellationToken cancellationToken = default)
    {
        if (!await _sharedUserRepository.UserIsExistsByEmail(login.Email))
        {
            throw new NotFoundException("email or password is incorrect!");
        }
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
}
