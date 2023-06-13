using Domain.DTOs.NotificationDTOs;
using Domain.Repositories.NotificationRepository;
using Domain.Repositories.SharedRepositories;
using Domain.Services.EmailService;
using Domain.Shared.Exceptions;

namespace Domain.Services.NotificationService;

public sealed class NotificationService : INotificationService
{
    private readonly IEmailService _emailService;
    private readonly INotificationRepository _notificationRepository;
    private readonly ISharedUserRepository _sharedUserRepository;
    private readonly IUnitOfWork _unitOfWork;

    public NotificationService(IEmailService emailService,
        INotificationRepository notificationRepository,
        ISharedUserRepository sharedUserRepository,
        IUnitOfWork unitOfWork)
    {
        _emailService = emailService;
        _notificationRepository = notificationRepository;
        _sharedUserRepository = sharedUserRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Notification> SendEmail
    (Guid userId, string massage, string subject,
        CancellationToken cancellationToken = default)
    {
        var (username, email) = await _sharedUserRepository
            .FindUserEmailAndUsernameById(userId);
        var notification = new Notification(userId, massage);
        await _emailService.SendAsync
            (email, massage, username, subject, cancellationToken);
        var result = await _notificationRepository
            .AddNotification(notification);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return result;
    }
}