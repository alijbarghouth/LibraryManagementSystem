using Domain.Features.UserService.DTOs;

namespace Domain.Features.UserService.Services.RegisterService;

public interface IRegisterService
{
    Task<RegisterUser> RegisterUser(RegisterUser register, CancellationToken cancellationToken = default);
}
