using System.Threading.Tasks;
using N36_HT_Task1.Servislar;

namespace N36_HT_Task1
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var userservice = new UserService();
            var emailService = new EmailService();
            var emailtemplateService = new EmailTemplateService();
            var senderEmailService = new EmailSenderService();
            var notificationService =
                new NotificationManagementService(userservice, emailService, emailtemplateService, senderEmailService);
            await notificationService.NotifiyUserAsync();
        }
    }
}