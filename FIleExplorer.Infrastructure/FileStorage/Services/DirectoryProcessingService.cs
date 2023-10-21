using FileExplorer.Application.FIleStorage.Brokers;
using FileExplorer.Application.FIleStorage.Models.Storage;
using FileExplorer.Application.Services;
using Training.FileExplorer.Application.FileStorage.Models.Filtering;
using Training.FileExplorer.Application.FileStorage.Services;

namespace FIleExplorer.Infrastructure.FileStorage.Services
{
    public class DirectoryProcessingService : IDirectoryProcessingService
    {
        private readonly IDirectoryService  _directoryService;
        private readonly IFileService _fileService;

        public DirectoryProcessingService(IDirectoryService directoryService, IFileService fileService)
        {
            _directoryService = directoryService;
            _fileService = fileService;
        }

        public async ValueTask<List<IStorageEntry>> GetEntriesAsync(string directoryPath, StorageDriveEntryFilterModel filterModel)
        {
            var storage = new List<IStorageEntry>();
            if (filterModel.IncludeDirectories)
                storage.AddRange(await _directoryService.GetSubDirectoriesAsync(directoryPath, filterModel));
            if (filterModel.IncludeFiles)
                storage.AddRange(await _fileService.GetFiles(directoryPath, filterModel));
            return storage;

        }
    }
}
