using FileExplorer.Application.FIleStorage.Models.Storage;
using Training.FileExplorer.Application.FileStorage.Models.Filtering;

namespace Training.FileExplorer.Application.FileStorage.Services;

public interface IDriveProcessingService
{
    ValueTask<List<IStorageEntry>> GetEntriesAsync(string drivePath, StorageDriveEntryFilterModel filterModel);
}