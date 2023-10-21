using FileExplorer.Application.FIleStorage.Models.Storage;
using FileExplorer.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.FileExplorer.Application.FileStorage.Models.Filtering;
using Training.FileExplorer.Application.FileStorage.Services;

namespace FIleExplorer.Infrastructure.FileStorage.Services
{
    public class DriveProcessingService : IDriveProcessingService
    {
        private readonly IDriveService _driveService;
        private readonly IDirectoryService _directoryService;
        private readonly IFileService  _fileService;

        public DriveProcessingService(IDriveService driveService, IDirectoryService directoryService, IFileService fileService)
        {
            _driveService = driveService;
            _directoryService = directoryService;
            _fileService = fileService;
        }

        public async ValueTask<List<IStorageEntry>> GetEntriesAsync(string drivePath, StorageDriveEntryFilterModel filterModel)
        {
            var driver = new List<IStorageEntry>();
            if (filterModel.IncludeDirectories)
                driver.AddRange(await _directoryService.GetSubDirectoriesAsync(drivePath, filterModel));
            if (filterModel.IncludeFiles)
                driver.AddRange(await _fileService.GetFiles(drivePath, filterModel));
            return driver;
        }
    }
}
