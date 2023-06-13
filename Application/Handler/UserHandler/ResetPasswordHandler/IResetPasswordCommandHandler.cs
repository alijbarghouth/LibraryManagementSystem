using Application.Command.UserCommand;

namespace Application.Handler.UserHandler.ResetPasswordHandler;

public interface IResetPasswordCommandHandler
{
    Task<bool> Handel(ResetPasswordCommand command);
}