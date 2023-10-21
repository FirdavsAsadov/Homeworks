using FileExplorer.Application.FIleStorage.Models.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplorer.Application.FIleStorage.Brokers
{
    public interface IDriveBroker
    {
        IEnumerable<StorageDrive> Get();
    }
}
