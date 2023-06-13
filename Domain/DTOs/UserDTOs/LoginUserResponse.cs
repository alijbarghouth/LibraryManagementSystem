namespace Domain.DTOs.UserDTOs;

public sealed class LoginUserResponse
{
    public string Token { get; set; }
    public string RefreshToken { get; set; }

    public LoginUserResponse(string token, string refreshToken)
    {
        Token = token;
        RefreshToken = refreshToken;
    }
}