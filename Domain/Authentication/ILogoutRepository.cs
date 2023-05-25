namespace Domain.Authentication;

public interface ILogoutRepository
{
    Task Logout(string token);
    Task<bool> IsActiveAsync(string token);
}
