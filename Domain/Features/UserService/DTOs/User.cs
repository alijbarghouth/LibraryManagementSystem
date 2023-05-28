using System.ComponentModel.DataAnnotations;

namespace Domain.Features.UserService.DTOs;

public sealed class User
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    public string Password { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
