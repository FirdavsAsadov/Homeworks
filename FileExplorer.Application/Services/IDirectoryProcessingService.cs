using FileExplorer.Application.FIleStorage.Models.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.FileExplorer.Application.FileStorage.Models.Filtering;

namespace FileExplorer.Application.Services
{
    public interface IDirectoryProcessingService
    {
        ValueTask<List<IStorageEntry>> GetEntriesAsync(string directoryPath, StorageDriveEntryFilterModel filterModel);

    }
}
