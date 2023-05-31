using Domain.Features.UserService.DTOs;
using Domain.Features.UserService.SharedRepositories;
using Domain.Shared.Exceptions;
using Domain.Shared.Exceptions.CustomException;
using System.Threading;

namespace Domain.Features.UserService.Services.LoginService;

public class LoginService : ILoginService
{
    private readonly ISharedRepository _sharedRepository;
    private readonly ILoginRepository _loginRepository;
    private readonly IUnitOfWork _unitOfWork;
    public LoginService(ISharedRepository sharedRepository, ILoginRepository loginRepository
        , IUnitOfWork unitOfWork)
    {
        _sharedRepository = sharedRepository;
        _loginRepository = loginRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<(string, string)> LoginUser(LoginUser login, CancellationToken cancellationToken = default)
    {
        if (!await _sharedRepository.UserIsExistsByEmail(login.Email))
        {
            throw new LibraryNotFoundException("email or password is incorrect!");
        }
        var tokens =  await _loginRepository.LoginUser(login);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return tokens;
    }

    public async Task<(string, string)> RefreshToken(string token, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(token))
            throw new LibraryNotFoundException("token not found");
        var tokens = await _loginRepository.RefreshToken(token);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return tokens;
    }
}
