using Application.Cashing;
using Application.Query.InteractionQuery;
using Domain.DTOs.InteractionDTOs;
using Domain.DTOs.Response;
using Domain.Services.InteractionService;

namespace Application.Handler.InteractionHandler.GetAllInteractionQueryHandler;

public sealed class GetAllInteractionQueryHandler : IGetAllInteractionQueryHandler
{
    private readonly IInteractionService _interactionService;
    private readonly ICashService _cashService;

    public GetAllInteractionQueryHandler(IInteractionService interactionService,
        ICashService cashService)
    {
        _interactionService = interactionService;
        _cashService = cashService;
    }

    public async Task<List<Response<Interaction>>> Handel(GetAllInteractionQuery query)
    {
        var key = query.BookReviewId.ToString();
        return await _cashService.GetAsync<List<Response<Interaction>>>
        (key, async () =>
        {
            var interaction = await _interactionService.GetAllInteractionByBookReviewId(query.BookReviewId);
            return interaction;
        });
    }
}