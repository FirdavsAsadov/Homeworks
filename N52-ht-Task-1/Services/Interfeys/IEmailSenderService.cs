using N52_ht_Task_1.Models;

namespace N52_ht_Task_1.Services.Interfeys
{
    public interface IEmailSenderService
    {
        Task SendEmailAsync(User user);

    }
}
