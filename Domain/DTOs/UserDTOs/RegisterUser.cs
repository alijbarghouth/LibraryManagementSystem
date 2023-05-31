using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs.UserDTOs;

public record RegisterUser
(
     string FirstName,
     string LastName,
     string Username,
    [EmailAddress]
     string Email,
     string Password,
     DateTime CreatedAt,
     DateTime? UpdatedAt
);
