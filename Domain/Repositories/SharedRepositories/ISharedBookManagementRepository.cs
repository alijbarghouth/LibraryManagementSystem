namespace Domain.Repositories.SharedRepositories;

public interface ISharedBookManagementRepository
{
    Task<bool> IsOrderExistsByOrderId(Guid orderId);
    Task<bool> IsBookExistsByTitle(string bookTitle);
    Task<bool> IsBookExistsByBookId(Guid bookId);
    Task<bool> IsGenreExistsByTitle(string bookGenre);
    Task<bool> IsGenreExistsById(Guid genreId);
    Task<bool> IsAuthorExistsByAuthorName(string authorName);
    Task<bool> IsAuthorExistsByAuthorId(Guid authorId);
    Task<bool> IsReadingListExistsByAuthorId(Guid readingListId);
    Task<bool> IsBookExistsInReadingList(Guid bookId);
    Task<bool> IsBookReviewExistsByBookReviewId(Guid bookReviewId);
    Task<bool> IsInteractionExistsByInteractionId(Guid bookReviewId);
    Task<bool> IsInteractionExistsByBookReviewIdAndUserId(Guid userId, Guid bookReviewId);
    Task<bool> IsReviewExistsByBookIdAndUserId(Guid userId, Guid bookId);
    Task<bool> IsReadingListExistsByBookIdAndUserId(Guid userId, Guid bookId);
}