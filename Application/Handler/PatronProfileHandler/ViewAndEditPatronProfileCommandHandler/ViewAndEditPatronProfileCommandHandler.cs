using Application.Command.PatronProfileCommand;
using Domain.DTOs.PatronProfileDTOs;
using Domain.Services.PatronProfile;

namespace Application.Handler.PatronProfileHandler.ViewAndEditPatronProfileCommandHandler;

public class ViewAndEditPatronProfileCommandHandler : IViewAndEditPatronProfileCommandHandler
{
    private readonly IPatronProfileService _patronProfileService;

    public ViewAndEditPatronProfileCommandHandler(IPatronProfileService patronProfileService)
    {
        _patronProfileService = patronProfileService;
    }

    public async Task<PatronProfile> Handel(ViewAndEditPatronProfileCommand command)
    {
        return await _patronProfileService.ViewAndEditPatronProfile(command.PatronProfile, command.OrderId);
    }
}