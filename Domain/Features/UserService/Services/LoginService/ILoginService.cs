using Domain.Features.UserService.DTOs;

namespace Domain.Features.UserService.Services.LoginService;

public interface ILoginService
{
    Task<(string, string)> LoginUser(LoginUser login, CancellationToken cancellationToken = default);
    Task<(string, string)> RefreshToken(string token, CancellationToken cancellationToken = default);
}
