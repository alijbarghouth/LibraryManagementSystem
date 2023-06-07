using Domain.Repositories.ModerationRepository;
using Domain.Shared.Exceptions;

namespace Domain.Services.ModerationService;

public class ModerationService : IModerationService
{
    private readonly IModerationRepository _moderationRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ModerationService(IModerationRepository moderationRepository,
        IUnitOfWork unitOfWork)
    {
        _moderationRepository = moderationRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> DeleteReview
        (string massage, Guid bookReviewId, CancellationToken cancellationToken = default)
    {
        var result = await _moderationRepository.DeleteReview(massage, bookReviewId);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return result;
    }
}