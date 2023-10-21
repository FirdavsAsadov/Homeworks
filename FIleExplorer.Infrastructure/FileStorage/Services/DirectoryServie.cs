using FileExplorer.Application.Common.Models.Filtering;
using FileExplorer.Application.FIleStorage.Brokers;
using FileExplorer.Application.FIleStorage.Models.Storage;
using FileExplorer.Application.Querying.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.FileExplorer.Application.FileStorage.Services;

namespace FIleExplorer.Infrastructure.FileStorage.Services
{
    public class DirectoryServie : IDirectoryService
    {
        private readonly IDirectoryBroker  _directoryBroker;
        public DirectoryServie(IDirectoryBroker directoryBroker)
        {
            _directoryBroker = directoryBroker;
        }
        public ValueTask<StorageDirectory?> GetByPathAsync(string directoryPath)
        {
            if(string.IsNullOrWhiteSpace(directoryPath))
                throw new ArgumentNullException(nameof(directoryPath));
   
            return new ValueTask<StorageDirectory?>(_directoryBroker.GetByPathAsync(directoryPath));     
        }

        public async ValueTask<IList<StorageDirectory>> GetSubDirectoriesAsync(string directoryPath, FilterPagination paginationOptions)
        {
            if(string.IsNullOrWhiteSpace(directoryPath))
                throw new ArgumentNullException(nameof(directoryPath));

            var subDirectoryinThisboot = _directoryBroker.GetDirectoriesPath(directoryPath).ToList().Select(x =>
            {
                try
                {
                    var onlyThisBoot = _directoryBroker.SetAccessControl(x);
                    var test = _directoryBroker.GetByPathAsync(x);
                    return test;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex);
                }
                return new StorageDirectory();

            }).ToList();
            var directory = await Task.Run(() =>
                _directoryBroker.GetDirectoriesPath(directoryPath).ApplyPagination(paginationOptions)
                .Select(subDirectory => _directoryBroker.GetByPathAsync(subDirectory)));
            return directory.ToList();
        }
    }
}
