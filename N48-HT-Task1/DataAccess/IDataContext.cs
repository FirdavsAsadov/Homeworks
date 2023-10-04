using FileBaseContext.Abstractions.Models.FileSet;
using N48_HT_Task1.Models;

namespace N48_HT_Task1.DataAccess
{
    public interface IDataContext
    {
        IFileSet<User, Guid> Users { get; }
        IFileSet<Order, Guid>  Orders { get; }
        ValueTask SaveChangesAsync();
    }
}
