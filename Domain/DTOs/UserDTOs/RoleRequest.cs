namespace Domain.DTOs.UserDTOs;

public record RoleRequest
(
     Guid UserId,
     string RoleName
);
