using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs.UserDTOs;

public record UpdateLibrarianRequest
(
    string FirstName,
    string LastName,
    string Username,
    [EmailAddress] string Email,
    string Password,
    DateTime CreatedAt
);