using Application.Command.UserCommand;
using Domain.DTOs.UserDTOs;
using Domain.Services.UserService.AuthService;
using Domain.Shared.Exceptions;

namespace Application.Handler.UserHandler.UpdateLibrarianHandler;

public class UpdateLibrarianRequestCommandHandler : IUpdateLibrarianRequestCommandHandler
{
    private readonly IAuthService _authService;
    private readonly IUnitOfWork _unitOfWork;
    public UpdateLibrarianRequestCommandHandler(IAuthService authService, IUnitOfWork unitOfWork)
    {
        _authService = authService;
        _unitOfWork = unitOfWork;
    }

    public async Task<UpdateLibrarianRequest> Handel
        (UpdateLibrarianRequestCommand command, CancellationToken cancellationToken = default)
    {
        var result = await _authService.UpdateLibrarianAccount(command.UserId, command.UpdateLibrarianRequest);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return result;
    }
}