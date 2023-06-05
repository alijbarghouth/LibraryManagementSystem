using Application.Command.AuthorCommand;
using Domain.DTOs.AuthorDTOs;
using Domain.DTOs.Response;
using Domain.Services.AuthorService;

namespace Application.Handler.AuthorHandler.AddAuthorCommandHandler;

public sealed class AddAuthorCommandHandler : IAddAuthorCommandHandler
{
    private readonly IAuthorCrudsService _authorCrudsService;

    public AddAuthorCommandHandler(IAuthorCrudsService authorCrudsService)
    {
        _authorCrudsService = authorCrudsService;
    }

    public async Task<Response<Author>> Handel(AddAuthorCommand command)
    {
        return await _authorCrudsService.AddAuthor(command.Author);
    }
}
