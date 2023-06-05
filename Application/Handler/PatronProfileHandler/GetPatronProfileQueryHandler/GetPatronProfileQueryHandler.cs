using Application.Cashing;
using Application.Query.PatronProfile;
using Domain.DTOs.PatronProfileDTOs;
using Domain.Services.PatronProfile;

namespace Application.Handler.PatronProfileHandler.GetPatronProfileQueryHandler;

public sealed class GetPatronProfileQueryHandler : IGetPatronProfileQueryHandler
{
    private readonly IPatronProfileService _patronProfileService;
    private readonly ICashService _cashService;

    public GetPatronProfileQueryHandler(IPatronProfileService patronProfileService,
        ICashService cashService)
    {
        _patronProfileService = patronProfileService;
        _cashService = cashService;
    }

    public async Task<List<PatronProfile>> Handel(PatronProfileQuery query,
        CancellationToken cancellationToken = default)
    {
        return await _cashService.GetAsync(query.UserId.ToString(),
            async () =>
            {
                var orders = await _patronProfileService.GetPatronProfile(query.UserId);
                return orders;
            }, cancellationToken);
    }
}