using Domain.Authentication;
using Domain.Features.UserService.Services.LoginService;
using Domain.Shared.Exceptions.CustomException;
using Infrastructure.DBContext;
using Infrastructure.HashingPassword;
using Infrastructure.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApi.Settings;

namespace Infrastructure.Features.UserFeature.Repositories;

public sealed class LoginRepository : ILoginRepository
{
    private readonly LibraryDBContext _libraryDBContext;
    private readonly JWT _jwt;
    public LoginRepository(LibraryDBContext libraryDBContext, IOptions<JWT> jwt)
    {
        _libraryDBContext = libraryDBContext;
        _jwt = jwt.Value;
    }

    public async Task<string> LoginUser(Domain.Features.UserService.DTOs.LoginRequest login)
    {
        var user = await _libraryDBContext.Users
            .FirstOrDefaultAsync(x => x.Email == login.Email)
            ?? throw new LibraryNotFoundException("user is not found");
        if (!login.Password.VerifyingPassword(user.PasswordHash, user.PasswordSlot))
        {
            throw new LibraryBadRequestException("The password is wrong");
        }
        var token = new JwtSecurityTokenHandler().WriteToken(CreateJwtToken(user));

        return token;
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
}
