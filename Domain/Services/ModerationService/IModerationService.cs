namespace Domain.Services.ModerationService;

public interface IModerationService
{
    Task<bool> DeleteReview
        (string massage, Guid bookReviewId, CancellationToken cancellationToken = default);
}