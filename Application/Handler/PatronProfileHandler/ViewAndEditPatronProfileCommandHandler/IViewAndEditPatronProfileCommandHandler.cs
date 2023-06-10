using Application.Command.PatronProfileCommand;
using Domain.DTOs.PatronProfileDTOs;

namespace Application.Handler.PatronProfileHandler.ViewAndEditPatronProfileCommandHandler;

public interface IViewAndEditPatronProfileCommandHandler
{
    Task<PatronProfile> Handel(ViewAndEditPatronProfileCommand command);
}