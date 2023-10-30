using Microsoft.Extensions.Options;
using N64.Identity.Application.Common.NotificationService;
using N64.Identity.Application.Common.Settings;
using System.Net;
using System.Net.Mail;

namespace N64.Identity.Infrastructure.Common.NotificationService;

public class EmailOrchestrationService : IEmailOrchestrationService
{
    private readonly EmailSenderSettings _settings;

    public EmailOrchestrationService(IOptions<EmailSenderSettings> settings)
    {
        _settings = settings.Value;
    }

    public ValueTask<bool> SendAsync(string emailAddress, string message)
    {
        var mail = new MailMessage(_settings.CredentialAddress, emailAddress);
        mail.Subject = "Siz Muvaffaqyatli ro'yxatdan o'tdingiz!";
        mail.Body = message;

        var smtpClient = new SmtpClient(_settings.Host, _settings.Port);
        smtpClient.Credentials = new NetworkCredential(_settings.CredentialAddress, _settings.Password);
        smtpClient.EnableSsl = true;

        smtpClient.Send(mail);

        return new(true);
    }
}
