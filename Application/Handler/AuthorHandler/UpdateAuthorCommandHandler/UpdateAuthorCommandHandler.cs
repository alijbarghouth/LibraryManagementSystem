using Application.Command.AuthorCommand;
using Domain.DTOs.AuthorDTOs;
using Domain.Services.AuthorService;

namespace Application.Handler.AuthorHandler.UpdateAuthorCommandHandler;

public sealed class UpdateAuthorCommandHandler : IUpdateAuthorCommandHandler
{
    private readonly IAuthorCrudsService _authorCrudsService;

    public UpdateAuthorCommandHandler(IAuthorCrudsService authorCrudsService)
    {
        _authorCrudsService = authorCrudsService;
    }

    public async Task<Author> Handel(UpdateAuthorCommand command)
    {
        return await _authorCrudsService.UpdateAuthor(command.AuthorId, command.Author);
    }
}