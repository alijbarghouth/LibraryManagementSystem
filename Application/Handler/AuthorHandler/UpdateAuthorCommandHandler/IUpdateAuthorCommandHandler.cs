using Application.Command.AuthorCommand;
using Domain.DTOs.AuthorDTOs;
using Domain.DTOs.Response;

namespace Application.Handler.AuthorHandler.UpdateAuthorCommandHandler;

public interface IUpdateAuthorCommandHandler
{
    Task<Response<Author>> Handel(UpdateAuthorCommand command);
}