using Application.Command.UserCommand;
using Domain.DTOs.Response;
using Domain.DTOs.UserDTOs;
using Domain.Services.UserService.RegisterService;

namespace Application.Handler.UserHandler.RegisterHandler;

public sealed class RegisterUserCommandHandler : IRegisterUserCommandHandler
{
    private readonly IRegisterService _registerService;

    public RegisterUserCommandHandler(IRegisterService registerService)
    {
        _registerService = registerService;
    }

    public async Task<Response<RegisterUser>> Handle(RegisterUserCommand command)
    {
        return await _registerService.RegisterUser(command.RegisterUser);
    }
}
