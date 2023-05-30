namespace Domain.Features.UserService.DTOs;

public record RoleRequest
(
     Guid UserId,
     string RoleName
);
