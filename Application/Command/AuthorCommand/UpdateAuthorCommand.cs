using Domain.DTOs.AuthorDTOs;

namespace Application.Command.AuthorCommand;

public record UpdateAuthorCommand
(
    Guid AuthorId,
    Author Author
);