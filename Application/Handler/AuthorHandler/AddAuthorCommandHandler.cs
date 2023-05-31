using Application.Command.AuthorCommand;
using Domain.DTOs.AuthorDTOs;
using Domain.Services.AuthorService;

namespace Application.Handler.AuthorHandler;

public sealed class AddAuthorCommandHandler : IAddAuthorCommandHandler
{
    private readonly IAuthorService _authorService;

    public AddAuthorCommandHandler(IAuthorService authorService)
    {
        _authorService = authorService;
    }

    public async Task<Author> Handel(AddAuthorCommand command)
    {
        return await _authorService.AddAuthor(command.Author);
    }
}
