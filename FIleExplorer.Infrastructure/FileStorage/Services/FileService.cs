using AutoMapper;
using FileExplorer.Application.Common.Models.Filtering;
using FileExplorer.Application.FIleStorage.Brokers;
using FileExplorer.Application.FIleStorage.Models.Storage;
using FileExplorer.Application.Querying.Extensions;
using FileExplorer.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIleExplorer.Infrastructure.FileStorage.Services
{
    public class FileService : IFileService
    {
        private readonly IMapper _mapper;
        private readonly IFileBroker _fileBroker;
        private readonly IDirectoryBroker _directoryBroker;
        public FileService(IMapper mapper, IFileBroker fileBroker, IDirectoryBroker directoryBroker)
        {
            _mapper = mapper;
            _fileBroker = fileBroker;
            _directoryBroker = directoryBroker;
        }
        public async ValueTask<IList<StorageFile>> GetFiles(string directoryPath, FilterPagination paginationOptions)
        {
            if(string.IsNullOrWhiteSpace(directoryPath))
                throw new ArgumentNullException(nameof(directoryPath));

            if(!_directoryBroker.ExistsAsync(directoryPath))
                throw new ArgumentException("this directory is not existing",nameof(directoryPath));

            var files = await Task.Run(() =>
                _directoryBroker
                .GetFilesPath(directoryPath)
                .ApplyPagination(paginationOptions)
                .Select(file => _fileBroker.GetByPath(file)));
            return files.ToList();
        }
    }
}
