namespace Domain.Repositories.SharedRepositories;

public interface ISharedUserRepository
{
    Task<bool> UserIsExistByUsername(string username);
    Task<bool> UserIsExistsByEmail(string email);
    Task<bool> UserIsExistsUserId(Guid userId);
}
