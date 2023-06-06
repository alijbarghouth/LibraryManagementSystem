using Application.Query.InteractionQuery;
using Domain.DTOs.InteractionDTOs;
using Domain.DTOs.Response;

namespace Application.Handler.InteractionHandler.GetAllInteractionQueryHandler;

public interface IGetAllInteractionQueryHandler
{
    Task<List<Response<Interaction>>> Handel(GetAllInteractionQuery query);
}