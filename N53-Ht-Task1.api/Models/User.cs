using FileBaseContext.Abstractions.Models.Entity;
using N53_Ht_Task1.api.DataAccess;

namespace N53_Ht_Task1.api.Models;

public class User : IEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }   
    public User(string name, string email)
    {
        Id = Guid.NewGuid();
        Name = name;
        Email = email;
    }
}