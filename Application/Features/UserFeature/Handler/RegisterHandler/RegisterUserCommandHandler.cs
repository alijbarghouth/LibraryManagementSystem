using Application.Features.UserFeature.Command;
using Domain.Features.UserService.DTOs;
using Domain.Features.UserService.Services.RegisterService;
using Domain.Shared.Exceptions.CustomException;

namespace Application.Features.UserFeature.Handler.RegisterHandler;

public sealed class RegisterUserCommandHandler : IRegisterUserCommandHandler
{
    private readonly IRegisterService _registerService;

    public RegisterUserCommandHandler(IRegisterService registerService)
    {
        _registerService = registerService;
    }

    public async Task<RegisterUser> Handle(RegisterUserCommand command)
    {
        return await _registerService.RegisterUser(command.RegisterUser);
    }
}
