using FileBaseContext.Abstractions.Models.FileSet;
using N53_Ht_Task1.api.Models;

namespace N53_Ht_Task1.api.DataAccess;

public interface IDataContext
{
    IFileSet<User, Guid> Users { get; }
    IFileSet<Order, Guid> Orders { get; }
    IFileSet<Bonus, Guid> Bonus { get; }

    ValueTask SaveChangesAsync();
}