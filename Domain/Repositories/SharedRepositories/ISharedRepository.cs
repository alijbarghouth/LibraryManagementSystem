namespace Domain.Repositories.SharedRepositories;

public interface ISharedRepository
{
    Task<bool> UserIsExistByUsername(string username);
    Task<bool> UserIsExistsByEmail(string email);
    Task<bool> UserIsExistsUserId(Guid userId);
    Task<bool> OrderIsExistsByOrderId(Guid orderId);
    Task<bool> IsBookExistsByTitle(string bookTitle);
    Task<bool> IsBookExistsByBookId(Guid bookId);
    Task<bool> IsBookGenreExists(string bookGenre);
    Task<bool> IsBookGenreExistsById(Guid genreId);
}
