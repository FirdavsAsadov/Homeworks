namespace N64.Identity.Domain.Entities;

public class Token
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string TokenValue { get; set; } = string.Empty;
    public DateTime ExpiryTime { get; set; }

}
