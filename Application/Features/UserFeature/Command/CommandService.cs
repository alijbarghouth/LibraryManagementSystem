using Domain.Features.UserService.DTOs;
using Domain.Features.UserService.Services.LoginService;
using Domain.Features.UserService.Services.RegisterService;
using Domain.Shared.Exceptions.CustomException;

namespace Application.Features.UserFeature.Command;

public sealed class CommandService : ICommandService
{
    private readonly IRegisterService _registerService;
    private readonly ILoginService _loginService;
    public CommandService(IRegisterService registerService, ILoginService loginService)
    {
        _registerService = registerService;
        _loginService = loginService;
    }

    public async Task<string> LoginUser(LoginRequest request)
    {
        if (request is null)
            throw new LibraryNotFoundException("request not found");

        return await _loginService.LoginUser(request);
    }

    public async Task<User> RegisterUser(User register)
    {
        if (register is null)
            throw new LibraryNotFoundException("user not found");

        return await _registerService.RegisterUser(register);
    }
}
