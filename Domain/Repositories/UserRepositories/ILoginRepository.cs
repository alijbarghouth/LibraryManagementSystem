using Domain.DTOs.UserDTOs;

namespace Domain.Repositories.UserRepositories;

public interface ILoginRepository
{
    Task<(string, string)> LoginUser(LoginUser login);
    Task<(string, string)> RefreshToken(string token);
    Task<string> GetUserId(LoginUser user);
    Task ConfirmedEmail(Guid userId);
}
