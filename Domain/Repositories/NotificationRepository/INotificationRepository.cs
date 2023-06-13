using Domain.DTOs.NotificationDTOs;

namespace Domain.Repositories.NotificationRepository;

public interface INotificationRepository
{
    Task<Notification> AddNotification
        (Notification notificationDtOs);
}