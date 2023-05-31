namespace Application.Features.UserFeature.Handler.RefreshTokenHandler;

public interface IRefreshTokenQueryHandler
{
    Task<(string, string)> RefreshToken(string token);
}
