namespace Domain.Repositories.SharedRepositories;

public interface ISharedUserRepository
{
    Task<bool> IsUserExistByUsername(string username);
    Task<bool> IsUserExistsByEmail(string email);
    Task<bool> IsUserExistsUserId(Guid userId);
}
