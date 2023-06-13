namespace Domain.Services.EmailService;

public interface IEmailService
{
    Task<bool> SendAsync
        (string email, string body,string subject, string username, CancellationToken ct = default);
}