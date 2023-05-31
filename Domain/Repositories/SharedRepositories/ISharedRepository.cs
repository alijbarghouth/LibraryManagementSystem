namespace Domain.Repositories.SharedRepositories;

public interface ISharedRepository
{
    Task<bool> UserIsExistByUsername(string username);
    Task<bool> UserIsExistsByEmail(string email);
}
