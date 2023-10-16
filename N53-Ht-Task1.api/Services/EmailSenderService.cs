using N53_Ht_Task1.api.Interfeys;

namespace N53_Ht_Task1.api.Services
{
    public class EmailSenderService : INotificationService
    {
        public ValueTask SendAsync(Guid userId, string content)
        {
            Console.WriteLine($"Sending email to {userId} with this content {content}");
            return new ValueTask();
        }
    }
}
