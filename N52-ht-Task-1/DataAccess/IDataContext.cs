using FileBaseContext.Abstractions.Models.FileSet;
using N52_ht_Task_1.Models;

namespace N52_ht_Task_1.DataAccess
{
    public interface IDataContext : IAsyncDisposable
    {
        IFileSet<User, Guid> Users { get; }
        ValueTask SaveChangesAsync();
    }
}
