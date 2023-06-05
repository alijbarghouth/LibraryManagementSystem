using Domain.DTOs.UserDTOs;
using Domain.Repositories.UserRepositories;
using Domain.Shared.Exceptions;
using Domain.Shared.Exceptions.CustomException;

namespace Domain.Services.UserService.LoginService;

public class LoginService : ILoginService
{
    private readonly ILoginRepository _loginRepository;
    private readonly IUnitOfWork _unitOfWork;

    public LoginService(ILoginRepository loginRepository
        , IUnitOfWork unitOfWork)
    {
        _loginRepository = loginRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<(string, string)> LoginUser(LoginUser login, CancellationToken cancellationToken = default)
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
        return await _loginRepository.GetUserId(loginUser);
    }
}