
namespace Domain.Repositories.ModerationRepository;

public interface IModerationRepository
{
    Task<bool> DeleteReview(string massage, Guid bookReviewId);
}