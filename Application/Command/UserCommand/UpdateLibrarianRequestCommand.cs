using Domain.DTOs.UserDTOs;

namespace Application.Command.UserCommand;

public record UpdateLibrarianRequestCommand
(
    UpdateLibrarianRequest UpdateLibrarianRequest,
    Guid UserId
);