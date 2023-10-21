using FileExplorer.Application.Common.Models.Filtering;
using FileExplorer.Application.FIleStorage.Models.Storage;

namespace Training.FileExplorer.Application.FileStorage.Services;

public interface IDirectoryService
{
    ValueTask<IList<StorageDirectory>> GetSubDirectoriesAsync(string directoryPath, FilterPagination paginationOptions);

    ValueTask<StorageDirectory?> GetByPathAsync(string directoryPath);
}