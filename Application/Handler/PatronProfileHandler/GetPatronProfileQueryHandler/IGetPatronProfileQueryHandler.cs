using Application.Query.PatronProfile;
using Domain.DTOs.PatronProfileDTOs;

namespace Application.Handler.PatronProfileHandler.GetPatronProfileQueryHandler;

public interface IGetPatronProfileQueryHandler
{
    Task<List<PatronProfile>> Handel(PatronProfileQuery query, CancellationToken cancellationToken = default);
}