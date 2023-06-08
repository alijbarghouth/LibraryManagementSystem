using Domain.DTOs.UserDTOs;

namespace Domain.Services.UserService.LoginService;

public interface ILoginService
{
    Task<(string, string)> LoginUser(LoginUser login, CancellationToken cancellationToken = default);
    Task<(string, string)> RefreshToken(string token, CancellationToken cancellationToken = default);
    Task<string> GetUserId(LoginUser user);
    Task ConfirmedEmail(Guid userId, CancellationToken cancellationToken = default);
}