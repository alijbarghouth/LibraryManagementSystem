using Application.Command.AuthorCommand;
using Domain.DTOs.AuthorDTOs;

namespace Application.Handler.AuthorHandler.AddAuthorCommandHandler;

public interface IAddAuthorCommandHandler
{
    Task<Author> Handel(AddAuthorCommand command);
}
