using Application.Command.UserCommand;
using Domain.DTOs.Response;
using Domain.DTOs.UserDTOs;

namespace Application.Handler.UserHandler.RegisterHandler;

public interface IRegisterUserCommandHandler
{
    Task<Response<RegisterUser>> Handle(RegisterUserCommand command);
}
