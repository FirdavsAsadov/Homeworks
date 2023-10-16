namespace N53_Ht_Task1.api.Interfeys
{
    public interface INotificationService
    {
        ValueTask SendAsync(Guid userId, string content);
    }
}
