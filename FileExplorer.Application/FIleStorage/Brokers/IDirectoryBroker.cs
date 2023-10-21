using FileExplorer.Application.FIleStorage.Models.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplorer.Application.FIleStorage.Brokers
{
    public interface IDirectoryBroker
    {
        IEnumerable<string> GetDirectoriesPath(string directoryPath);

        IEnumerable<string> GetFilesPath(string directoryPath);

        StorageDirectory GetByPathAsync(string directoryPath);

        bool ExistsAsync(string directoryPath);

        bool SetAccessControl(string directoryPath);
    }
}
