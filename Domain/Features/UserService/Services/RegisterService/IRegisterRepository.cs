using Domain.Features.UserService.DTOs;

namespace Domain.Features.UserService.Services.RegisterService;

public interface IRegisterRepository
{
    Task<User> RegisterUser(User register);
}