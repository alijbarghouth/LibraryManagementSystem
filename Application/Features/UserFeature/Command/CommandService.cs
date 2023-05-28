using Domain.Features.UserService.DTOs;
using Domain.Features.UserService.Services.AuthService;
using Domain.Features.UserService.Services.LoginService;
using Domain.Features.UserService.Services.RegisterService;
using Domain.Shared.Exceptions.CustomException;

namespace Application.Features.UserFeature.Command;

public sealed class CommandService : ICommandService
{
    private readonly IRegisterService _registerService;
    private readonly ILoginService _loginService;
    private readonly IAuthService _authService;
    public CommandService(IRegisterService registerService, ILoginService loginService, IAuthService authService)
    {
        _registerService = registerService;
        _loginService = loginService;
        _authService = authService;
    }

    public async Task<(string, string)> LoginUser(LoginRequest request)
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

    public async Task<bool> AddRole(RoleRequest request)
    {
        return await _authService.AddRole(request);
    }
}
