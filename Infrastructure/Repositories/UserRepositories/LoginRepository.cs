using Domain.DTOs.UserDTOs;
using Domain.Repositories.UserRepositories;
using Domain.Shared.Exceptions.CustomException;
using Infrastructure.DBContext;
using Infrastructure.HashingPassword;
using Infrastructure.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using WebApi.Settings;

namespace Infrastructure.Repositories.UserRepositories;

public sealed class LoginRepository : ILoginRepository
{
    private readonly LibraryDBContext _libraryDbContext;
    private readonly JWT _jwt;

    public LoginRepository(LibraryDBContext libraryDbContext, IOptions<JWT> jwt)
    {
        _libraryDbContext = libraryDbContext;
        _jwt = jwt.Value;
    }

    public async Task<(string, string)> LoginUser(LoginUser login)
    {
        var user = await _libraryDbContext.Users
            .FirstOrDefaultAsync(x => x.Email == login.Email);

        if (!login.Password.VerifyingPassword(user.PasswordHash, user.PasswordSlot))
        {
            throw new BadRequestException("The password is wrong");
        }

        var token = new JwtSecurityTokenHandler().WriteToken(CreateJwtToken(user));
        var refreshToken = new RefreshToken();
        if (user.RefreshTokens.Any(x => x.IsActive))
        {
            refreshToken = user.RefreshTokens.FirstOrDefault(x => x.IsActive);
            return (token, refreshToken.Token);
        }


        refreshToken = GenerateRefreshToken();
        user.RefreshTokens.Add(refreshToken);
        _libraryDbContext.Users.Update(user);

        return (token, refreshToken.Token);
    }

    public async Task<(string, string)> RefreshToken(string token)
    {
        var user = await _libraryDbContext.Users
                       .SingleOrDefaultAsync(u => u.RefreshTokens.Any(t => t.Token == token))
                   ?? throw new BadRequestException("Invalid token");

        var refreshToken = user.RefreshTokens.Single(t => t.Token == token)
                           ?? throw new BadRequestException("Inactive token");

        refreshToken.RevokedOn = DateTime.UtcNow;

        var newRefreshToken = GenerateRefreshToken();
        user.RefreshTokens.Add(newRefreshToken);
        _libraryDbContext.Update(user);

        var jwtToken = new JwtSecurityTokenHandler().WriteToken(CreateJwtToken(user));
        return (jwtToken, newRefreshToken.Token);
    }

    private JwtSecurityToken CreateJwtToken(User user)
    {
        var roleClaims = new List<Claim>();

        foreach (var role in user.Roles)
        {
            roleClaims.Add(new Claim("role", role.RoleName));
        }

        var claims = new[]
        {
            new Claim("uid", user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Sub, user.Username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
        }.Union(roleClaims);

        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

        var jwtSecurityToken = new JwtSecurityToken(
            issuer: _jwt.Issuer,
            audience: _jwt.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_jwt.DurationInMinutes),
            signingCredentials: signingCredentials);

        return jwtSecurityToken;
    }

    private static RefreshToken GenerateRefreshToken()
    {
        var randomNumber = new byte[32];

        using var generator = RandomNumberGenerator.Create();

        generator.GetBytes(randomNumber);

        return new RefreshToken
        {
            Token = Convert.ToBase64String(randomNumber),
            ExpiresOn = DateTime.UtcNow.AddDays(3),
            CreatedOn = DateTime.UtcNow
        };
    }
}