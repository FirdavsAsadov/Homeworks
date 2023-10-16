using N53_Ht_Task1.api.Interfeys;

namespace N53_Ht_Task1.api.Services
{
    public class TelegramSenderService : INotificationService
    {
        public ValueTask SendAsync(Guid userId, string content)
        {
            Console.WriteLine($"Sending telegram to {userId} with content {content}");
            return new ValueTask();
        }
    }
}
