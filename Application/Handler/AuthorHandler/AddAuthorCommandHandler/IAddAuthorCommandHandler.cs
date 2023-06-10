using Application.Command.AuthorCommand;
using Domain.DTOs.AuthorDTOs;
using Domain.DTOs.Response;

namespace Application.Handler.AuthorHandler.AddAuthorCommandHandler;

public interface IAddAuthorCommandHandler
{
    Task<Response<Author>> Handel(AddAuthorCommand command);
}
