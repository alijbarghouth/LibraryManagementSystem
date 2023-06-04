using Domain.Authentication;

namespace Application.Authentication;

public class LogoutService : ILogoutService
{
    private readonly ILogoutRepository _logoutRepository;

    public LogoutService(ILogoutRepository logoutRepository)
    {
        _logoutRepository = logoutRepository;
    }

    public async Task Logout(string token)
    {
        await _logoutRepository.Logout(token);
    }

    public async Task<bool> IsActiveAsync(string token)
    {
        return await _logoutRepository.IsActiveAsync(token);
    }
}