using Domain.Features.UserService.DTOs;

namespace Domain.Features.UserService.Services.LoginService;

public interface ILoginService
{
    Task<string> LoginUser(LoginRequest login);
}
