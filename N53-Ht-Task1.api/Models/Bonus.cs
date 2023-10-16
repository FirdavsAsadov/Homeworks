using N53_Ht_Task1.api.DataAccess;

namespace N53_Ht_Task1.api.Models;

public class Bonus : IEntity
{
    public Guid Id { get; set; }
    public decimal Amount { get; set; }
    public Guid UserId { get; set; }

    public Bonus(Guid id, decimal amount, Guid userId)
    {
        Id = id;
        Amount = amount;
        UserId = userId;    
    }
}