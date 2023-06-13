namespace Domain.DTOs.NotificationDTOs;

public record Notification
(
    Guid UserId,
    string Message
);