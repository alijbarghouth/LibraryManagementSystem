using Domain.DTOs.NotificationDTOs;

namespace Domain.Services.NotificationService;

public interface INotificationService
{
    Task<Notification> SendEmail
    (Guid userId, string massage, string subject,
        CancellationToken cancellationToken = default);
}