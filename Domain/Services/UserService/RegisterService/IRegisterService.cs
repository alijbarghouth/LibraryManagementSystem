using Domain.DTOs.Response;
using Domain.DTOs.UserDTOs;

namespace Domain.Services.UserService.RegisterService;

public interface IRegisterService
{
    Task<Response<RegisterUser>> RegisterUser(RegisterUser register, CancellationToken cancellationToken = default);
}
