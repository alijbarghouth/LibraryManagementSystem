using Application.Command.UserCommand;
using Domain.DTOs.UserDTOs;

namespace Application.Handler.UserHandler.RegisterHandler;

public interface IRegisterUserCommandHandler
{
    Task<RegisterUser> Handle(RegisterUserCommand command);
}
