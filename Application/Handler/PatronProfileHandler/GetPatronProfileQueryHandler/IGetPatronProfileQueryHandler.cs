using Application.Query.PatronProfile;
using Domain.DTOs.PatronProfileDTOs;
using Domain.DTOs.Response;

namespace Application.Handler.PatronProfileHandler.GetPatronProfileQueryHandler;

public interface IGetPatronProfileQueryHandler
{
    Task<List<Response<PatronProfile>>> Handel(PatronProfileQuery query, CancellationToken cancellationToken = default);
}