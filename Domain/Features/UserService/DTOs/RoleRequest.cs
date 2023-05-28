namespace Domain.Features.UserService.DTOs;

public sealed class RoleRequest
{
    public Guid  UserId { get; set; }
    public string  RoleName { get; set; }
}
