using Domain.DTOs.Response;
using Domain.DTOs.UserDTOs;

namespace Domain.Repositories.UserRepositories;

public interface IRegisterRepository
{
    Task<Response<RegisterUser>> RegisterUser(RegisterUser register);
}