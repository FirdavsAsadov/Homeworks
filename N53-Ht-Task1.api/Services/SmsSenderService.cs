using N53_Ht_Task1.api.Interfeys;

namespace N53_Ht_Task1.api.Services
{
    public class SmsSenderService : INotificationService
    {
        public ValueTask SendAsync(Guid userId, string content)
        {
            Console.WriteLine($"Sending sms this user {userId} with content {content}");
            return new ValueTask();
        }
    }
}
