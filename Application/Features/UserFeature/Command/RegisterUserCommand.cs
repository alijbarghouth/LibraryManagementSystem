using Domain.Features.UserService.DTOs;

namespace Application.Features.UserFeature.Command;

public record RegisterUserCommand(
    RegisterUser RegisterUser
    );
