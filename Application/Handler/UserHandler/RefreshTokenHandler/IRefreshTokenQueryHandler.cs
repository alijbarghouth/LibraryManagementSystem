namespace Application.Handler.UserHandler.RefreshTokenHandler;

public interface IRefreshTokenQueryHandler
{
    Task<(string, string)> RefreshToken(string token);
}
