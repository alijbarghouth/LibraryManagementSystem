using Domain.Features.UserService.DTOs;

namespace Domain.Features.UserService.Services.RegisterService;

public interface IRegisterService
{
    Task<User> RegisterUser(User register, CancellationToken cancellationToken = default);
}
