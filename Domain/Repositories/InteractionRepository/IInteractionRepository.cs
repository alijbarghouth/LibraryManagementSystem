using Domain.DTOs.InteractionDTOs;
using Domain.DTOs.Response;

namespace Domain.Repositories.InteractionRepository;

public interface IInteractionRepository
{
    Task<Response<Interaction>> AddInteraction(Interaction interaction);
    Task<Response<Interaction>> UpdateInteraction(Interaction interaction, Guid interactionId);

    Task<bool> DeleteInteraction(Guid interactionId);

    Task<List<Response<Interaction>>> GetAllInteractionByBookReviewId(Guid bookReviewId);
}