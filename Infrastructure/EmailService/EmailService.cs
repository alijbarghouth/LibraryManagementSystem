using Domain.DTOs.EmailDTOs;
using Domain.Services.EmailService;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using MailKit.Security;

namespace Infrastructure.EmailService;

public class EmailService : IEmailService
{
    private readonly MailSettings _settings;

    public EmailService(IOptions<MailSettings> settings)
    {
        _settings = settings.Value;
    }

    public async Task<bool> SendAsync(string email, string body, string username, string subject,
        CancellationToken ct = default)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress(_settings.DisplayName, _settings.From));
        message.To.Add(new MailboxAddress(username, email));
        message.Subject = subject;
        message.Body = new TextPart("plain")
        {
            Text = body
        };

        using var client = new SmtpClient();
        if (_settings.UseSSL)
        {
            await client.ConnectAsync(_settings.Host, _settings.Port, SecureSocketOptions.SslOnConnect, ct);
        }
        else if (_settings.UseStartTls)
        {
            await client.ConnectAsync(_settings.Host, _settings.Port, SecureSocketOptions.StartTls, ct);
        }

        await client.AuthenticateAsync(_settings.UserName, _settings.Password, ct);
        await client.SendAsync(message, ct);
        await client.DisconnectAsync(true, ct);


        return true;
    }
}