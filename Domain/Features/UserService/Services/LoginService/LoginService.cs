using Domain.Features.UserService.DTOs;
using Domain.Features.UserService.SharedRepositories;
using Domain.Shared.Exceptions.CustomException;

namespace Domain.Features.UserService.Services.LoginService;

public class LoginService : ILoginService
{
    private readonly ISharedRepository _sharedRepository;
    private readonly ILoginRepository _loginRepository;
    public LoginService(ISharedRepository sharedRepository, ILoginRepository loginRepository)
    {
        _sharedRepository = sharedRepository;
        _loginRepository = loginRepository;
    }

    public async Task<(string, string)> LoginUser(LoginRequest login)
    {
        if (!await _sharedRepository.UserIsExistsByEmail(login.Email))
        {
            throw new LibraryBadRequestException("email or password is incorrect!");
        }
        return await _loginRepository.LoginUser(login);
    }
}
