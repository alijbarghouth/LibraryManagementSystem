using Application.Query.PatronProfile;
using Domain.DTOs.PatronProfileDTOs;
using Domain.Services.PatronProfile;

namespace Application.Handler.PatronProfileHandler.GetPatronProfileQueryHandler;

public class GetPatronProfileQueryHandler : IGetPatronProfileQueryHandler
{
    private readonly IPatronProfileService _patronProfileService;

    public GetPatronProfileQueryHandler(IPatronProfileService patronProfileService)
    {
        _patronProfileService = patronProfileService;
    }

    public async Task<List<PatronProfile>> Handel(PatronProfileQuery query)
    {
        return await _patronProfileService.GetPatronProfile(query.UserId);
    }
}