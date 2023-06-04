namespace Application.Authentication;

public interface ILogoutService
{
    Task Logout(string token);
    Task<bool> IsActiveAsync(string token);
}