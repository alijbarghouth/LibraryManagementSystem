using Application.Query.PatronProfile;
using Domain.DTOs.PatronProfileDTOs;
using Domain.Services.PatronProfile;

namespace Application.Handler.PatronProfileHandler;

public class PatronProfileQueryHandler : IPatronProfileQueryHandler
{
    private readonly IPatronProfileService _patronProfileService;

    public PatronProfileQueryHandler(IPatronProfileService patronProfileService)
    {
        _patronProfileService = patronProfileService;
    }

    public async Task<List<PatronProfile>> Handel(PatronProfileQuery query)
    {
        return await _patronProfileService.GetPatronProfile(query.UserId);
    }
}