using Application.Command.AuthorCommand;
using Domain.DTOs.AuthorDTOs;

namespace Application.Handler.AuthorHandler.UpdateAuthorCommandHandler;

public interface IUpdateAuthorCommandHandler
{
    Task<Author> Handel(UpdateAuthorCommand command);
}