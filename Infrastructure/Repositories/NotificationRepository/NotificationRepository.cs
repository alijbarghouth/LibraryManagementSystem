using Domain.Repositories.NotificationRepository;
using Infrastructure.DBContext;
using Infrastructure.Model;
using Mapster;

namespace Infrastructure.Repositories.NotificationRepository;

public class NotificationRepository : INotificationRepository
{
    private readonly LibraryDbContext _libraryDbContext;

    public NotificationRepository(LibraryDbContext libraryDbContext)
    {
        _libraryDbContext = libraryDbContext;
    }

    public async Task<Domain.DTOs.NotificationDTOs.Notification>
        AddNotification
        (Domain.DTOs.NotificationDTOs.Notification notificationDtOs)
    {
        var notification = notificationDtOs.Adapt<Notification>();
        await _libraryDbContext.Notifications.AddAsync(notification);
        return notificationDtOs;
    }
}