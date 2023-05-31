using Domain.DTOs.UserDTOs;

namespace Domain.Services.Services.LoginService;

public interface ILoginService
{
    Task<(string, string)> LoginUser(LoginUser login, CancellationToken cancellationToken = default);
    Task<(string, string)> RefreshToken(string token, CancellationToken cancellationToken = default);
}
