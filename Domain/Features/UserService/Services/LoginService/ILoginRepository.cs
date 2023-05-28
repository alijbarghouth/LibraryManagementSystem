using Domain.Features.UserService.DTOs;

namespace Domain.Features.UserService.Services.LoginService;

public interface ILoginRepository
{
    Task<(string, string)> LoginUser(LoginRequest login); 
}
