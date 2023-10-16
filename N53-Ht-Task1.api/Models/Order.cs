using N53_Ht_Task1.api.DataAccess;

namespace N53_Ht_Task1.api.Models;

public class Order : IEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Amount { get; set;}
    public Guid UserId { get; set; }

    public Order(string name, decimal amount)
    {
        Id = Guid.NewGuid();
        Name = name;
        Amount = amount;
        UserId = Guid.NewGuid();    
    }
}