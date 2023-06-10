namespace Domain.DTOs.UserDTOs;

public record ResetPassword
(
    string Email,
    string CurrentPassword,
    string NewPassword
);