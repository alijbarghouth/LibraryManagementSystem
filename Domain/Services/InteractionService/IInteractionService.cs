using Domain.DTOs.InteractionDTOs;
using Domain.DTOs.Response;

namespace Domain.Services.InteractionService;

public interface IInteractionService
{
    Task<Response<Interaction>> AddInteraction
        (Interaction interaction, CancellationToken cancellationToken = default);

    Task<Response<Interaction>> UpdateInteraction
        (Interaction interaction, Guid interactionId, CancellationToken cancellationToken = default);

    Task<bool> DeleteInteraction
        (Guid interactionId, CancellationToken cancellationToken = default);

    Task<List<Response<Interaction>>> GetAllInteractionByBookReviewId(Guid bookReviewId);
}