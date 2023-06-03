using Application.Command.AuthorCommand;
using Domain.Services.AuthorService;

namespace Application.Handler.AuthorHandler.DeleteAuthorCommandHandler;

public class DeleteAuthorCommandHandler : IDeleteAuthorCommandHandler
{
    private readonly IAuthorCrudsService _authorCrudsService;

    public DeleteAuthorCommandHandler(IAuthorCrudsService authorCrudsService)
    {
        _authorCrudsService = authorCrudsService;
    }

    public async Task<bool> Handel(DeleteAuthorCommand command)
    {
        return await _authorCrudsService.DeleteAuthor(command.AuthorId);
    }
}