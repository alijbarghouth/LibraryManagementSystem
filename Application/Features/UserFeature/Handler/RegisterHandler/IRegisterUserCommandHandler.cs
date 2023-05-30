using Application.Features.UserFeature.Command;
using Domain.Features.UserService.DTOs;

namespace Application.Features.UserFeature.Handler.RegisterHandler;

public interface IRegisterUserCommandHandler
{
    Task<RegisterUser> Handle(RegisterUserCommand command);
}
