using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace N36_HT_Task1.Servislar
{
    public class EmailSenderService
    {
        public async Task SendEmailAsync(IEnumerable<EmailMessage> emailMessages)
        {
            var smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("sultonbek.rakhimov.recovery@gmail.com", "szabguksrhwsbtie");
            smtp.EnableSsl = true;

            foreach (var message in emailMessages)
            {
                var mail = new MailMessage(message.SenderAddress, message.ReceiverAddress);
                mail.Subject = message.Subject;
                mail.Body = message.Body;

                await smtp.SendMailAsync(mail);
            }
        }
    }
}