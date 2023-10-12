using N52_ht_Task_1.Models;
using N52_ht_Task_1.Services.Interfeys;
using System.Net.Mail;
using System.Net;

namespace N52_ht_Task_1.Services
{
    public class EmailSenderService : IEmailSenderService
    {
        
        
            public async Task SendEmailAsync(User user)
            {
                var smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential("sultonbek.rakhimov.recovery@gmail.com", "szabguksrhwsbtie");
                smtp.EnableSsl = true;

                var fullName = $"{user.FirstName} {user.LastName}";
                var mail = new MailMessage("sultonbek.rakhimov.recovery@gmail.com", user.Email);
                mail.Subject = Message.Subject;
                mail.Body = Message.Body.Replace("{{FullName}}", fullName);

                await smtp.SendMailAsync(mail);
            }
        
    }
}
