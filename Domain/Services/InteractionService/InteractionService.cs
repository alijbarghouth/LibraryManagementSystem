using Domain.DTOs.InteractionDTOs;
using Domain.DTOs.Response;
using Domain.Repositories.InteractionRepository;
using Domain.Repositories.SharedRepositories;
using Domain.Shared.Exceptions;
using Domain.Shared.Exceptions.CustomException;

namespace Domain.Services.InteractionService;

public sealed class InteractionService : IInteractionService
{
    private readonly IInteractionRepository _interactionRepository;
    private readonly ISharedUserRepository _sharedUserRepository;
    private readonly ISharedBookManagementRepository _sharedBookManagementRepository;
    private readonly IUnitOfWork _unitOfWork;

    public InteractionService(IInteractionRepository interactionRepository,
        ISharedUserRepository sharedUserRepository,
        ISharedBookManagementRepository sharedBookManagementRepository,
        IUnitOfWork unitOfWork)
    {
        _interactionRepository = interactionRepository;
        _sharedUserRepository = sharedUserRepository;
        _sharedBookManagementRepository = sharedBookManagementRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Response<Interaction>> AddInteraction
        (Interaction interaction, CancellationToken cancellationToken = default)
    {
        if (!await _sharedUserRepository.IsUserExistsUserId(interaction.UserId))
            throw new NotFoundException("user not found");
        if (!await _sharedBookManagementRepository
                .IsBookReviewExistsByBookReviewId(interaction.BookReviewId))
            throw new NotFoundException("BookReviewId not found");
        if (await _sharedBookManagementRepository
                .IsInteractionExistsByBookReviewIdAndUserId(interaction.UserId, interaction.BookReviewId))
            throw new NotFoundException("interaction is already  found");
        var result = await _interactionRepository.AddInteraction(interaction);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return result;
    }

    public async Task<Response<Interaction>> UpdateInteraction
    (Interaction interaction, Guid interactionId,
        CancellationToken cancellationToken = default)
    {
        if (!await _sharedBookManagementRepository.IsBookReviewExistsByBookReviewId(interaction.BookReviewId))
            throw new NotFoundException("BookReview not found");
        if (!await _sharedUserRepository.IsUserExistsUserId(interaction.UserId))
            throw new NotFoundException("user not found");
        if (!await _sharedBookManagementRepository.IsInteractionExistsByInteractionId(interactionId))
            throw new NotFoundException("interaction not found");
        var result = await _interactionRepository.UpdateInteraction(interaction, interactionId);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return result;
    }

    public async Task<bool> DeleteInteraction
        (Guid interactionId, CancellationToken cancellationToken = default)
    {
        if (!await _sharedBookManagementRepository.IsInteractionExistsByInteractionId(interactionId))
            throw new NotFoundException("interaction not found");
        var result = await _interactionRepository.DeleteInteraction(interactionId);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return result;
    }

    public async Task<List<Response<Interaction>>> GetAllInteractionByBookReviewId(Guid bookReviewId)
    {
        return await _interactionRepository.GetAllInteractionByBookReviewId(bookReviewId);
    }
}