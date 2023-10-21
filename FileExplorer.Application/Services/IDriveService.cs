using FileExplorer.Application.FIleStorage.Models.Storage;

namespace Training.FileExplorer.Application.FileStorage.Services;

public interface IDriveService
{
    ValueTask<IList<StorageDrive>> GetAsync();
}