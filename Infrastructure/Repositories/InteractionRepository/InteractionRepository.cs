using Domain.DTOs.Response;
using Domain.Repositories.InteractionRepository;
using Infrastructure.DBContext;
using Infrastructure.Model;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.InteractionRepository;

public sealed class InteractionRepository : IInteractionRepository
{
    private readonly LibraryDbContext _libraryDbContext;

    public InteractionRepository(LibraryDbContext libraryDbContext)
    {
        _libraryDbContext = libraryDbContext;
    }

    public async Task<Response<Domain.DTOs.InteractionDTOs.Interaction>> AddInteraction
        (Domain.DTOs.InteractionDTOs.Interaction interactionDto)
    {
        var interaction = interactionDto.Adapt<Interaction>();
        await _libraryDbContext.Interactions.AddAsync(interaction);
        return new Response<Domain.DTOs.InteractionDTOs.Interaction>(interactionDto, interaction.Id);
    }

    public async Task<Response<Domain.DTOs.InteractionDTOs.Interaction>>
        UpdateInteraction(Domain.DTOs.InteractionDTOs.Interaction interaction, Guid interactionId)
    {
        var oldInteraction = await _libraryDbContext.Interactions
            .FindAsync(interactionId);
        var newInteraction = interaction.Adapt(oldInteraction);
        _libraryDbContext.Interactions.Update(newInteraction);
        return new Response<Domain.DTOs.InteractionDTOs.Interaction>(interaction, newInteraction.Id);
    }

    public async Task<bool>
        DeleteInteraction(Guid interactionId)
    {
        var interaction = await _libraryDbContext.Interactions
            .FindAsync(interactionId);
        _libraryDbContext.Interactions.Remove(interaction);
        return true;
    }

    public async Task<List<Response<Domain.DTOs.InteractionDTOs.Interaction>>>
        GetAllInteractionByBookReviewId(Guid bookReviewId)
    {
        return await _libraryDbContext.Interactions
            .Where(x => x.BookReviewId == bookReviewId)
            .Select
            (x
                => new Response<Domain.DTOs.InteractionDTOs.Interaction>
                    (x.Adapt<Domain.DTOs.InteractionDTOs.Interaction>(), x.Id)
            )
            .ToListAsync();
    }
}