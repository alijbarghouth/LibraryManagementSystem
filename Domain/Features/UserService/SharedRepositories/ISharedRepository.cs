namespace Domain.Features.UserService.SharedRepositories;

public interface ISharedRepository
{
    Task<bool> FindUserByUsername(string username);
    Task<bool> FindUserByEmail(string email);
}
