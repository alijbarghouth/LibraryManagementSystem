using Domain.DTOs.UserDTOs;

namespace Domain.Repositories.UserRepositories;

public interface IRegisterRepository
{
    Task<RegisterUser> RegisterUser(RegisterUser register);
}