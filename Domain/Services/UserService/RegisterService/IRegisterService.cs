using Domain.DTOs.UserDTOs;

namespace Domain.Services.Services.RegisterService;

public interface IRegisterService
{
    Task<RegisterUser> RegisterUser(RegisterUser register, CancellationToken cancellationToken = default);
}
